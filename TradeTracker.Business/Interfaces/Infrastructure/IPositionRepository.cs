using System.Threading.Tasks;
using TradeTracker.Core.DomainModels.Position;
using TradeTracker.Core.DomainModels.Response;

namespace TradeTracker.Business.Interfaces.Infrastructure
{
    public interface IPositionsRepository
    {
        Task<PositionDomainModel> GetAsync(string symbol, string accessKey);
        Task<PaginatedResult<PositionDomainModel>> GetFilteredAsync(PositionFilterDomainModel filterModel, string accessKey);
    }
}
