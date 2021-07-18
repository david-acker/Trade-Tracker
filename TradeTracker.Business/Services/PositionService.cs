using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Core.DomainModels.Position;

namespace TradeTracker.Business.Services
{
    public interface IPositionService
    {
        Task<PositionDomainModel> GetPosition(string symbol, string accessKey);
        Task<PaginatedResult<PositionDomainModel>> GetFilteredPositions(PositionFilterDomainModel filterModel, string accessKey);
        ModelStateDictionary ValidatePositionFilterModel(PositionFilterDomainModel filterModel);
    }
    public class PositionService : IPositionService
    {
        private readonly IPositionsRepository _positionsRepository;

        public PositionService(
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

            if (filterModel.PageSize < 1)
            {
                errors.AddModelError("PageSize", "The page size cannot be less than one.");
            }

            if (filterModel.PositionType.HasValue)
            {
                char inputPositionType = filterModel.PositionType.Value;

                var validPositionTypes = new char[] { 'L', 'S' };

                if (!validPositionTypes.Contains(inputPositionType))
                {
                    errors.AddModelError("PositionType", "The transaction type must be a valid type: L - Long, S - Short.");
                }
            }

            if (!string.IsNullOrEmpty(filterModel.OrderByField))
            {
                string inputOrderByField = filterModel.OrderByField;

                var validOrderByFields = new string[]
                {
                    "Symbol",
                    "Quantity"
                };

                if (!validOrderByFields.Select(x => x.ToLower())
                                       .Contains(inputOrderByField.ToLower()))
                {
                    errors.AddModelError("OrderByField", $"The order by field must be a valid field: {string.Join(", ", validOrderByFields)}.");
                }
            }

            if (filterModel.OrderByDirection.HasValue)
            {
                char inputOrderByDirection = filterModel.OrderByDirection.Value;

                var validOrderByDirections = new char[] { 'A', 'D' };

                if (!validOrderByDirections.Contains(inputOrderByDirection))
                {
                    errors.AddModelError("OrderByDirection", "The order by direction must be a valid direction: A - Ascending, D - Descending.");
                }
            }

            return errors;
        }
    }
}
