using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Infrastructure.Services
{
    public class PositionTrackingService : IPositionTrackingService
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IPositionCalculator _positionCalculator;
        private readonly IPositionService _positionService;

        public PositionTrackingService(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IPositionCalculator positionCalculator,
            IPositionService positionService)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _positionCalculator = positionCalculator;
            _positionService = positionService;
        }

        public async Task RefreshAfterCreation(Guid transactionId)
        {
            await _positionCalculator.RefreshForTransaction(transactionId);
        }

        public async Task RefreshAfterCollectionCreation(Dictionary<string, List<Guid>> transactionMap)
        {
            foreach (var entry in transactionMap)
                await _positionCalculator.RefreshForTransactionCollection(entry.Value);
        }

        public async Task RefreshAfterModification( 
            Guid transactionId, 
            string symbolBeforeModification,
            TransactionType typeBeforeModification,
            decimal quantityBeforeModification)
        {
            var transaction = await _authenticatedTransactionRepository
                .GetByIdAsync(transactionId);

            string symbolForDetachment;

            if (symbolBeforeModification != transaction.Symbol)
                symbolForDetachment = symbolBeforeModification;
            else
                symbolForDetachment = transaction.Symbol;

            await _positionService
                .DetachFromPosition(
                    symbolForDetachment,
                    typeBeforeModification,
                    quantityBeforeModification);

            await _positionService
                .AttachToPosition(
                    transaction.Symbol,
                    transaction.Type,
                    transaction.Quantity);
        }

        public async Task RefreshAfterDeletion(
            string symbolBeforeDeletion, 
            TransactionType typeBeforeDeletion,
            decimal quantityBeforeDeletion)
        {
            await _positionService
                .DetachFromPosition(
                    symbolBeforeDeletion,
                    typeBeforeDeletion,
                    quantityBeforeDeletion);
        }
    }
}