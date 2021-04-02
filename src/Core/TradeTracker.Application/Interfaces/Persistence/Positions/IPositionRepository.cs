using System;
using System.Threading.Tasks;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence.Positions
{
    public interface IPositionRepository : 
        IAsyncRepository<Position, PagedPositionsResourceParameters, UnpagedPositionsResourceParameters>
    {
        Task<Position> GetBySymbolAsync(
            string symbol,
            Guid accessKey);
    }
}
