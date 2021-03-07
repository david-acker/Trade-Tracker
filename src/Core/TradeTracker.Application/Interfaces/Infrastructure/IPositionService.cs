using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Interfaces.Infrastructure
{
    public interface IPositionService
    { 
        Task AttachToPosition(
            Guid accessKey, 
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);

        Task DetachFromPosition(
            Guid accessKey, 
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);
        
        Task RecalculateForSymbol(
            Guid accessKey, 
            string symbol);

        Task RefreshForTransaction(
            Guid accessKey,
            Guid transactionId);

        Task RefreshForTransactionGroup(
            Guid accessKey,
            string symbol,
            List<Guid> transactionIds);
    }
}