using System;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface IPositionRepository : IAsyncRepository<Position>
    {
        Task<Position> GetBySymbolAsync(
            Guid accessKey, 
            string symbol);

        Task<PagedList<Position>> GetPagedPositionsAsync(
            Guid userAccessKey, 
            PagedPositionsResourceParameters parameters);
    }
}
