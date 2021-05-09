using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Enums;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Requests;
using TradeTracker.Domain.Entities;
using System.Linq;

namespace TradeTracker.Application.Common.Services
{
    public class PositionCalculator : IPositionCalculator
    {
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly ILogger<PositionCalculator> _logger;
        private readonly IPositionService _positionService;
        private readonly IPositionRepository _positionRepository;
        private readonly ITransactionRepository _transactionRepository;

        public PositionCalculator(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            ILogger<PositionCalculator> logger,
            IPositionService positionService,
            IPositionRepository positionRepository,
            ITransactionRepository transactionRepository)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _logger = logger;
            _positionService = positionService;
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
                await _positionService.HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    transaction.AccessKey,
                    transaction.Symbol);

                position.Attach(transaction);
                await _positionService.HandleNewPosition(position);
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
                await _positionService.HandleExistingPosition(position);
            }
            else
            {
                position = new Position(
                    accessKey,
                    symbol);

                position.AttachBatch(transactionCollection);
                await _positionService.HandleNewPosition(position);
            }
        }

        public async Task RecalculateForSymbol(
            string symbol,
            Guid accessKey)
        {
            var position = await _positionRepository
                .GetBySymbolAsync(symbol, accessKey);

            if (position != null)
            {
                await _positionRepository.DeleteAsync(position);
            }

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
            await _positionService.HandleNewPosition(position);
        }
    }
}
