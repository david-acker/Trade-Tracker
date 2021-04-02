using System.Threading.Tasks;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Interfaces.Persistence.Positions
{
    public interface IAuthenticatedPositionRepository : 
        IAuthenticatedAsyncRepository<Position, PagedPositionsResourceParameters, UnpagedPositionsResourceParameters>
    {
        Task<Position> GetBySymbolAsync(
            string symbol);
    }
}
