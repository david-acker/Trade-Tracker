using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models;
using TradeTracker.Domain.Common;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Infrastructure.Services
{
    public class PositionTrackingService : IPositionTrackingService
    {
        private readonly ILogger<PositionTrackingService> _logger;
        private readonly IPositionService _positionService;
        private readonly ITransactionRepository _transactionRepository;

        public PositionTrackingService(
            ILogger<PositionTrackingService> logger, 
            IPositionService positionService, 
            ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _positionService = positionService;
            _transactionRepository = transactionRepository;
        }

        public async Task RefreshAfterCreation(Guid accessKey, Guid transactionId)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(RefreshAfterCreation)} was called.");

            await _positionService.RefreshForTransaction(accessKey, transactionId);
        }

        public async Task RefreshAfterCollectionCreation(Guid accessKey, Dictionary<string, List<Guid>> transactionMap)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(RefreshAfterCollectionCreation)} was called.");

            foreach (var entry in transactionMap)
            {
                await _positionService.RefreshForTransactionCollection(accessKey, entry.Key, entry.Value);
            }
        }

        public async Task RefreshAfterModification(
            Guid accessKey, 
            Guid transactionId, 
            string symbolBeforeModification,
            TransactionType typeBeforeModification,
            decimal quantityBeforeModification)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(RefreshAfterModification)} was called.");

            var transaction = await _transactionRepository.GetByIdAsync(accessKey, transactionId);

            string symbolForDetachment;
            if (symbolBeforeModification != transaction.Symbol)
            {
                symbolForDetachment = symbolBeforeModification;
            }
            else
            {
                symbolForDetachment = transaction.Symbol;
            }

            await _positionService.DetachFromPosition(
                accessKey: accessKey,
                symbol: symbolForDetachment,
                transactionType: typeBeforeModification,
                quantity: quantityBeforeModification);

            await _positionService.AttachToPosition(
                accessKey: accessKey,
                symbol: transaction.Symbol,
                transactionType: transaction.Type,
                quantity: transaction.Quantity);
        }

        public async Task RefreshAfterDeletion(
            Guid accessKey, 
            string symbolBeforeDeletion, 
            TransactionType typeBeforeDeletion,
            decimal quantityBeforeDeletion)
        {
            _logger.LogInformation($"PositionTrackingService: {nameof(RefreshAfterDeletion)} was called.");

            await _positionService.DetachFromPosition(
                accessKey: accessKey,
                symbol: symbolBeforeDeletion,
                transactionType: typeBeforeDeletion,
                quantity: quantityBeforeDeletion);
        }
    }
}