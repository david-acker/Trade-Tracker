using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Core.DomainModels.Position;

namespace TradeTracker.Business.Services
{
    public interface IPositionsService
    {
        Task<PositionDomainModel> GetPosition(string symbol, string accessKey);
        Task<PaginatedResult<PositionDomainModel>> GetFilteredPositions(PositionFilterDomainModel filterModel, string accessKey);
        ModelStateDictionary ValidatePositionFilterModel(PositionFilterDomainModel filterModel);
    }
    public class PositionsService : IPositionsService
    {
        private readonly IPositionsRepository _positionsRepository;

        public PositionsService(
            IPositionsRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        public async Task<PositionDomainModel> GetPosition(string symbol, string accessKey)
        {
            return await _positionsRepository.GetAsync(symbol, accessKey);
        }

        public async Task<PaginatedResult<PositionDomainModel>> GetFilteredPositions(PositionFilterDomainModel filterModel, string accessKey)
        {
            return await _positionsRepository.GetFilteredAsync(filterModel, accessKey);
        }

        public ModelStateDictionary ValidatePositionFilterModel(PositionFilterDomainModel filterModel)
        {
            var errors = new ModelStateDictionary();

            if (filterModel.Page < 1)
            {
                errors.AddModelError("Page", "The page number cannot be less than one.");
            }

            if (filterModel.PageSize < 0)
            {
                errors.AddModelError("PageSize", "The page size must be greater than zero.");
            }

            return errors;
        }
    }
}
