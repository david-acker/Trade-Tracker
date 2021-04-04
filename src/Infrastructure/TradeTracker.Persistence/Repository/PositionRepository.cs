using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Positions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Domain.Entities;
using TradeTracker.Persistence.Extensions;

namespace TradeTracker.Persistence.Repositories
{
    public class PositionRepository : 
        BaseRepository<Position, PagedPositionsResourceParameters, UnpagedPositionsResourceParameters>, 
        IPositionRepository
    {
        public PositionRepository(
            TradeTrackerDbContext context) : base(context)
        {
        }

        public async Task<Position> GetBySymbolAsync(
            string symbol,
            Guid accessKey)
        {
            return await _context.Positions
                .ForAccessKey(accessKey)
                .Where(p => p.Symbol == symbol)
                .FirstOrDefaultAsync();
        }

        public override async Task<PagedList<Position>> GetPagedResponseAsync(
            PagedPositionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = _context.Positions
                .ForAccessKey(accessKey)
                .ForSymbolSelection(parameters.SymbolSelection)
                .ForExposureType(parameters.ExposureType)
                .ForOrderBy(parameters.OrderBy);

            return await PagedList<Position>.CreateAsync(
                query, parameters.PageNumber, parameters.PageSize);
        }

        public override async Task<IEnumerable<Position>> GetUnpagedResponseAsync(
            UnpagedPositionsResourceParameters parameters,
            Guid accessKey)
        {
            return await _context.Positions
                .ForAccessKey(accessKey)
                .ForSymbolSelection(parameters.SymbolSelection)
                .ForExposureType(parameters.ExposureType)
                .ForOrderBy(parameters.OrderBy)
                .ToListAsync();
        }
    }
}
