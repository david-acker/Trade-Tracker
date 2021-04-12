using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Interfaces.Infrastructure
{
    public interface IPositionTrackingService
    {
        Task RefreshAfterCreation(
            Guid transactionId);
        
        Task RefreshAfterCollectionCreation(
            Dictionary<string, List<Guid>> transactionMap);
        
        Task RefreshAfterModification(
            Guid transactionId, 
            string symbolBeforeModification,
            TransactionType typeBeforeModification,
            decimal quantityBeforeModification);
        
        Task RefreshAfterDeletion(
            string symbolBeforeDeletion,
            TransactionType typeBeforeDeletion,
            decimal quantityBeforeDeletion);
    }
}