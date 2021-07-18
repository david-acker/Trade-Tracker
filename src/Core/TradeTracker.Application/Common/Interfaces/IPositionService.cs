using System.Threading.Tasks;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;

namespace TradeTracker.Application.Common.Interfaces
{
    public interface IPositionService
    {
        Task AddPosition(Position position);

        Task UpdatePosition(Position position);

        Task ClosePosition(Position position);

        Task AttachToPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);

        Task DetachFromPosition(
            string symbol, 
            TransactionType transactionType, 
            decimal quantity);

        Task HandleNewPosition(Position position);

        Task HandleExistingPosition(Position position);
    }
}