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
using TradeTracker.Application.Interfaces;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Infrastructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ILogger<PositionService> _logger;
        private readonly IPositionRepository _positionRepository;
        private readonly ITransactionRepository _transactionRepository;

        public PositionService(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            ILoggedInUserService loggedInUserService,
            ILogger<PositionService> logger, 
            IPositionRepository positionRepository,
            ITransactionRepository transactionRepository)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _loggedInUserService = loggedInUserService;
            _logger = logger;
            _positionRepository = positionRepository;   
            _transactionRepository = transactionRepository;
        }

        public async Task RefreshForTransaction(Guid transactionId)
        {
            var transaction = await _authenticatedTransactionRepository
                .GetByIdAsync(transactionId);

            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(transaction.Symbol);

            if (position != null)
            {
                position.Attach(transaction);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    transaction.AccessKey,
                    transaction.Symbol);

                position.Attach(transaction);
                await HandleNewPosition(position);
            }
        }

        public async Task RefreshForTransactionCollection(List<Guid> transactionIds)
        {
            var transactionCollection = await _authenticatedTransactionRepository
                .GetTransactionCollectionByIdsAsync(transactionIds);

            var accessKey = transactionCollection.First().AccessKey;
            var symbol = transactionCollection.First().Symbol;

            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            if (position != null)
            {
                position.AttachBatch(transactionCollection);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    accessKey,
                    symbol);

                position.AttachBatch(transactionCollection);
                await HandleNewPosition(position);
            }
        }

        public async Task HandleNewPosition(Position position)
        {
            if (position.IsClosed)
                await AddPosition(position);
        }

        public async Task HandleExistingPosition(Position position)
        {
            if (position.IsClosed)
                await UpdatePosition(position);
            else
                await ClosePosition(position);
        }

        public async Task AddPosition(Position position)
        {
            await _positionRepository.AddAsync(position);
            _logger.LogInformation($"PositionService: {nameof(AddPosition)} - Added position for {position.Symbol}.");
        }

        public async Task UpdatePosition(Position position)
        {
            await _positionRepository.UpdateAsync(position);
            _logger.LogInformation($"PositionService: {nameof(UpdatePosition)} - Updating position for {position.Symbol}.");
        }

        public async Task ClosePosition(Position position)
        {
            await _positionRepository.DeleteAsync(position);
            _logger.LogInformation($"PositionService: {nameof(ClosePosition)} - Closed position for {position.Symbol}.");
        }

        public async Task AttachToPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            if (position != null)
            {
                position.Attach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    _loggedInUserService.AccessKey,
                    symbol);

                position.Attach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task DetachFromPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            if (position != null)
            {
                position.Detach(transactionType, quantity);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    _loggedInUserService.AccessKey,
                    symbol);

                position.Detach(transactionType, quantity);
                await HandleNewPosition(position);
            }
        }

        public async Task RecalculateForSymbol(
            string symbol, 
            Guid accessKey)
        {
            var position = await _positionRepository
                .GetBySymbolAsync(symbol, accessKey);

            if (position != null)
                await _positionRepository.DeleteAsync(position);

            var parametersForSymbol = new UnpagedTransactionsResourceParameters
            {
                SymbolSelection =
                    new SymbolSelection(
                        new List<string>() { symbol },
                        SelectionType.Include)
            };

            var transactionsForSymbol = await _transactionRepository
                .GetUnpagedResponseAsync(parametersForSymbol, accessKey);

            position = new Position(accessKey, symbol);

            position.AttachBatch(transactionsForSymbol);
            await HandleNewPosition(position);
        }

        public async Task<decimal> CalculateAverageCostBasis(
            string symbol)
        {
            var sourceRelations = await CreateSourceRelations(symbol);

            decimal totalNotional = sourceRelations
                .Sum(p => p.Quantity * p.TradePrice);

            decimal totalQuantity = sourceRelations
                .Sum(p => p.Quantity);

            return Math.Round(totalNotional / totalQuantity, 2);
        }

        public async Task<IEnumerable<SourceRelation>> CreateSourceRelations(
            string symbol)
        {
            var position = await _authenticatedPositionRepository
                .GetBySymbolAsync(symbol);

            var parametersForSymbol = new UnpagedTransactionsResourceParameters()
            {
                SymbolSelection = new SymbolSelection(
                    new List<string>() { symbol },
                    SelectionType.Include),
                TransactionType = TransactionType.Buy
            };

            IEnumerable<Transaction> transactionsForSymbol =
                await _authenticatedTransactionRepository
                    .GetUnpagedResponseAsync(parametersForSymbol);

            var sourceRelations = new List<SourceRelation>();
            var remainingQuantity = position.Quantity;

            foreach (var transaction in transactionsForSymbol)
            {
                var quantity = transaction.Quantity;
                var tradePrice = transaction.TradePrice;

                if (remainingQuantity > quantity)
                {
                    sourceRelations.Add(
                        new SourceRelation(transaction, quantity));
                    remainingQuantity -= quantity;
                }
                else
                {
                    sourceRelations.Add(
                        new SourceRelation(transaction, remainingQuantity));
                    break;
                }
            }

            return sourceRelations;
        }
    }
}