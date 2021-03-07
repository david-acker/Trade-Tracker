using System;
using System.Threading.Tasks;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface IPositionRepository : IAsyncRepository<Position>
    {
        Task<Position> GetBySymbolAsync(Guid accessKey, string symbol);
    }
}
