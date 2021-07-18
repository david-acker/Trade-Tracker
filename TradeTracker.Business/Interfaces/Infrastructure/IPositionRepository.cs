using System.Threading.Tasks;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Core.DomainModels.Position;

namespace TradeTracker.Business.Interfaces.Infrastructure
{
    public interface IPositionsRepository
    {
        Task<PositionDomainModel> GetAsync(string symbol, string accessKey);
        Task<PaginatedResult<PositionDomainModel>> GetFilteredAsync(PositionFilterDomainModel filterModel, string accessKey);
    }
}
