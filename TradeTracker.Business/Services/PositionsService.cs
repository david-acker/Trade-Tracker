using System.Threading.Tasks;
using TradeTracker.EntityModels.Models.Position;
using TradeTracker.Repository.Repositories;

namespace TradeTracker.Business.Services
{
    public interface IPositionsService
    {
        Task<Position> GetPosition(string symbol, string accessKey);
    }
    public class PositionsService : IPositionsService
    {
        private readonly IPositionsRepository _positionsRepository;

        public PositionsService(
            IPositionsRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        public async Task<Position> GetPosition(string symbol, string accessKey)
        {
            return await _positionsRepository.GetAsync(symbol, accessKey);
        }
    }
}
