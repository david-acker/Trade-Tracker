using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Positions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Interfaces;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Persistence.Repositories
{
    public class AuthenticatedPositionRepository : IAuthenticatedPositionRepository
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IPositionRepository _positionRepository;

        public AuthenticatedPositionRepository(
            ILoggedInUserService loggedInUserService,
            IPositionRepository positionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _positionRepository = positionRepository;
        }

        private Guid GetAccessKey()
        {
            if ((bool)_loggedInUserService?.IsLoggedIn())
                return _loggedInUserService.AccessKey;
            else
                throw new UnauthorizedAccessException("The current session has expired. Please reload and log back in.");
        }

        public async Task<Position> AddAsync(Position position)
        {
            position.AccessKey = GetAccessKey();

            return await _positionRepository.AddAsync(position);
        }

        public async Task<IEnumerable<Position>> AddRangeAsync(IEnumerable<Position> positions)
        {
            var accessKey = GetAccessKey();

            positions = positions
                .Select(position => 
                {
                    position.AccessKey = accessKey;
                    return position;
                });

            return await _positionRepository.AddRangeAsync(positions);
        }

        public async Task UpdateAsync(Position position)
        {
            position.AccessKey = GetAccessKey();

            await _positionRepository.UpdateAsync(position);
        }

        public async Task DeleteAsync(Position position)
        {
            position.AccessKey = GetAccessKey();

            await _positionRepository.DeleteAsync(position);
        }

        public async Task<Position> GetByIdAsync(Guid id)
        {
            return await _positionRepository
                .GetByIdAsync(id, GetAccessKey());
        }

        public async Task<Position> GetBySymbolAsync(string symbol)
        {
            return await _positionRepository
                .GetBySymbolAsync(symbol, GetAccessKey());
        }

        public async Task<PagedList<Position>> GetPagedResponseAsync(
            PagedPositionsResourceParameters parameters)
        {
            return await _positionRepository
                .GetPagedResponseAsync(parameters, GetAccessKey());
        }

        public async Task<IEnumerable<Position>> GetUnpagedResponseAsync(
            UnpagedPositionsResourceParameters parameters)
        {
            return await _positionRepository
                .GetUnpagedResponseAsync(parameters, GetAccessKey());
        }
    }
}