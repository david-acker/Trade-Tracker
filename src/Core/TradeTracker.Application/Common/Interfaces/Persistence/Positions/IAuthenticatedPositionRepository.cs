using System.Threading.Tasks;
using TradeTracker.Application.Common.Models.Resources.Parameters.Positions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Common.Interfaces.Persistence.Positions
{
    public interface IAuthenticatedPositionRepository : 
        IAuthenticatedAsyncRepository<Position, PagedPositionsResourceParameters, UnpagedPositionsResourceParameters>
    {
        Task<Position> GetBySymbolAsync(
            string symbol);
    }
}
