using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Extensions;

namespace TradeTracker.Infrastructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly ILogger<PositionService> _logger;
        private readonly IPositionRepository _positionRepository;
        private readonly ITransactionRepository _transactionRepository;

        public PositionService(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            ILogger<PositionService> logger, 
            IPositionRepository positionRepository,
            ITransactionRepository transactionRepository)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _logger = logger;
            _positionRepository = positionRepository;   
            _transactionRepository = transactionRepository;
        }

        public async Task RefreshForTransaction(
            Guid accessKey, 
            Guid transactionId)
        {
            _logger.LogInformation($"PositionService: {nameof(RefreshForTransaction)} was called for {transactionId}.");

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(transactionId);

            var position = await _positionRepository.GetBySymbolAsync(
                transaction.Symbol, accessKey);

            if (position != null)
            {
                position.Attach(transaction.Type, transaction.Quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(transaction.AccessKey, transaction.Symbol);

                position.Attach(transaction.Type, transaction.Quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task RefreshForTransactionCollection(
            string symbol, 
            List<Guid> transactionIds,
            Guid accessKey)
        {
            _logger.LogInformation($"PositionService: {nameof(RefreshForTransactionCollection)} was called for {symbol}.");

            var transactionCollectionForSymbol = await _transactionRepository
                .GetTransactionCollectionByIdsAsync(transactionIds, accessKey);

            var userAccessKey = transactionCollectionForSymbol.FirstOrDefault().AccessKey;

            var position = await _positionRepository.GetBySymbolAsync(symbol, accessKey);
            if (position != null)
            {
                AttachBatch(position, transactionCollectionForSymbol);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(userAccessKey, symbol);

                AttachBatch(position, transactionCollectionForSymbol);
                await HandleNewPosition(position);
            }
        }

        public void AttachBatch(Position position, IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Symbol == position.Symbol)
                {
                    position.Attach(transaction.Type, transaction.Quantity);
                }
            }
        }

        public async Task HandleNewPosition(Position position)
        {
            if (position.IsClosed())
            {
                await AddPosition(position);
            }
        }

        public async Task HandleExistingPosition(Position position)
        {
            if (position.IsClosed())
            {
                await UpdatePosition(position);
            }
            else
            {
                await ClosePosition(position);
            }            
        }

        public async Task AddPosition(Position position)
        {
            await _positionRepository.AddAsync(position);

            _logger.LogInformation($"PositionService: {nameof(AddPosition)} - Added position for {position.Symbol}.");
        }

        public async Task ClosePosition(Position position)
        {
            await _positionRepository.DeleteAsync(position);

            _logger.LogInformation($"PositionService: {nameof(ClosePosition)} - Closed position for {position.Symbol}.");
        }

        public async Task UpdatePosition(Position position)
        {
            await _positionRepository.UpdateAsync(position);

            _logger.LogInformation($"PositionService: {nameof(UpdatePosition)} - Updating position for {position.Symbol}.");
        }

        public async Task AttachToPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity,
            Guid accessKey)
        {
            _logger.LogInformation($"PositionService: {nameof(AttachToPosition)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(symbol, accessKey);
            if (position != null)
            {
                position.Attach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(accessKey, symbol);

                position.Attach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task DetachFromPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity, 
            Guid accessKey)
        {
            _logger.LogInformation($"PositionService: {nameof(DetachFromPosition)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(symbol, accessKey);
            if (position != null)
            {
                position.Detach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(accessKey, symbol);

                position.Detach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task RecalculateForSymbol(
            string symbol, 
            Guid accessKey)
        {
            _logger.LogInformation($"PositionService: {nameof(RecalculateForSymbol)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(symbol, accessKey);
            if (position != null)
            {
                await _positionRepository.DeleteAsync(position);
            }

            var parametersForSymbol = new UnpagedTransactionsResourceParameters();

            var symbolSelection = new SymbolSelection(
                new List<string>() { symbol },
                SelectionType.Include);

            parametersForSymbol.SymbolSelection = symbolSelection;

            var transactionHistory = await _transactionRepository
                .GetUnpagedResponseAsync(parametersForSymbol, accessKey);

            position = new Position(
                accessKey, 
                symbol);

            foreach (var transaction in transactionHistory)
            {
                position.Attach(transaction.Type, transaction.Quantity);
            }

            await HandleNewPosition(position);
        }

        public async Task<decimal> CalculateAverageCostBasis(
            string symbol)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(CalculateAverageCostBasis)} was called.");

            var sourceTransactionMap = await CreateSourceTransactionMap(symbol);

            decimal totalNotional = sourceTransactionMap
                .Sum(p => p.Quantity * p.TradePrice);

            decimal totalQuantity = sourceTransactionMap
                .Sum(p => p.Quantity);

            return Math.Round(totalNotional / totalQuantity, 2);
        }

        public async Task<IEnumerable<SourceTransactionLink>> CreateSourceTransactionMap(
            string symbol)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(CreateSourceTransactionMap)} was called.");
        
            var position = await _authenticatedPositionRepository.GetBySymbolAsync(symbol);

            var parametersForSymbol = new UnpagedTransactionsResourceParameters()
            {
                SymbolSelection = new SymbolSelection(
                    new List<string>() { symbol },
                    SelectionType.Include),
                TransactionType = TransactionType.Buy
            };

            var symbolSelection = new SymbolSelection(
                new List<string>() { symbol },
                SelectionType.Include);

            var transactionsForSymbol = await _authenticatedTransactionRepository
                .GetUnpagedResponseAsync(parametersForSymbol);

            var remainingOpenQuantity = position.Quantity;

            var sourceTransactionMap = new List<SourceTransactionLink>();
            
            foreach (var transaction in transactionsForSymbol)
            {
                var quantity = transaction.Quantity;
                var tradePrice = transaction.TradePrice;

                if (remainingOpenQuantity > quantity)
                {
                    sourceTransactionMap.Add(
                        new SourceTransactionLink(transaction, quantity));

                    remainingOpenQuantity -= quantity;
                }
                else
                {
                    sourceTransactionMap.Add(
                        new SourceTransactionLink(transaction, remainingOpenQuantity));

                    break;
                }
            }

            return sourceTransactionMap;
        }
    }
}