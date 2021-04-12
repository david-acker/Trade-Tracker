using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Positions;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Interfaces.Infrastructure
{
    public interface IPositionService
    { 
        Task AttachToPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);

        Task DetachFromPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);
        
        Task RecalculateForSymbol(
            string symbol,
            Guid accessKey);

        Task RefreshForTransaction(
            Guid transactionId);

        Task RefreshForTransactionCollection(
            List<Guid> transactionIds);

        Task<decimal> CalculateAverageCostBasis(
            string symbol);

        Task<IEnumerable<SourceRelation>> CreateSourceRelations(
            string symbol);
    }
}