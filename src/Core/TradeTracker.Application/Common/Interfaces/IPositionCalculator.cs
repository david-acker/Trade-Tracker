using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeTracker.Application.Common.Interfaces
{
    public interface IPositionCalculator
    {
        Task RefreshForTransaction(Guid transactionId);

        Task RefreshForTransactionCollection(List<Guid> transactionIds);

        Task RecalculateForSymbol(string symbol, Guid accessKey);
    }
}
