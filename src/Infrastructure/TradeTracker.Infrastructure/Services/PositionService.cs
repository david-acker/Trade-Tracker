using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Infrastructure.Services
{
    public class PositionService : IPositionService
    {
        private readonly ILogger<PositionService> _logger;
        private readonly IPositionRepository _positionRepository;
        private readonly ITransactionRepository _transactionRepository;

        public PositionService(
            ILogger<PositionService> logger, 
            IPositionRepository positionRepository,
            ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _positionRepository = positionRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task RefreshForTransaction(Guid accessKey, Guid transactionId)
        {
            _logger.LogInformation($"PositionService: {nameof(RefreshForTransaction)} was called for {transactionId}.");

            var transaction = await _transactionRepository.GetByIdAsync(accessKey, transactionId);

            var position = await _positionRepository.GetBySymbolAsync(transaction.AccessKey, transaction.Symbol);
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

        public async Task RefreshForTransactionGroup(Guid accessKey, string symbol, List<Guid> transactionIds)
        {
            _logger.LogInformation($"PositionService: {nameof(RefreshForTransactionGroup)} was called for {symbol}.");

            var transactionGroupForSymbol = await _transactionRepository
                .GetTransactionCollectionByIds(accessKey, transactionIds);

            var position = await _positionRepository.GetBySymbolAsync(accessKey, symbol);
            if (position != null)
            {
                AttachBatch(position, transactionGroupForSymbol);
                await HandleExistingPosition(position);
            }
            else
            {
                position = new Position(accessKey, symbol);

                AttachBatch(position, transactionGroupForSymbol);
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
            if (!position.IsClosed)
            {
                await AddPosition(position);
            }
        }

        public async Task HandleExistingPosition(Position position)
        {
            if (!position.IsClosed)
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


        public async Task AttachToPosition(Guid accessKey, string symbol, TransactionType transactionType, decimal quantity)
        {
            _logger.LogInformation($"PositionService: {nameof(AttachToPosition)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(accessKey, symbol);
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

        public async Task DetachFromPosition(Guid accessKey, string symbol, TransactionType transactionType, decimal quantity)
        {
            _logger.LogInformation($"PositionService: {nameof(DetachFromPosition)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(accessKey, symbol);
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


        public async Task RecalculateForSymbol(Guid accessKey, string symbol)
        {
            _logger.LogInformation($"PositionService: {nameof(RecalculateForSymbol)} was called for {symbol}.");

            var position = await _positionRepository.GetBySymbolAsync(accessKey, symbol);
            if (position != null)
            {
                await _positionRepository.DeleteAsync(position);
            }

            var transactionHistory = await _transactionRepository.GetAllTransactionsForSymbol(accessKey, symbol);

            position = new Position(accessKey, symbol);
            foreach (var transaction in transactionHistory)
            {
                position.Attach(transaction.Type, transaction.Quantity);
            }

            await HandleNewPosition(position);
        }
    }
}