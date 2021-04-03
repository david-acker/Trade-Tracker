using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Interfaces.Infrastructure
{
    public interface IPositionTrackingService
    {
        Task RefreshAfterCreation(
            Guid accessKey, 
            Guid transactionId);
        
        Task RefreshAfterCollectionCreation(
            Guid accessKey,
            Dictionary<string, List<Guid>> transactionMap);
        
        Task RefreshAfterModification(
            Guid accessKey, 
            Guid transactionId, 
            string symbolBeforeModification,
            TransactionType typeBeforeModification,
            decimal quantityBeforeModification);
        
        Task RefreshAfterDeletion(
            Guid accessKey, 
            string symbolBeforeDeletion,
            TransactionType typeBeforeDeletion,
            decimal quantityBeforeDeletion);
    }
}