using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Persistence.Repositories
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(TradeTrackerDbContext context) : base(context)
        {
        }

        public async Task<Position> GetBySymbolAsync(Guid accessKey, string symbol)
        {
            return await _context.Positions
                .Where(t => t.AccessKey == accessKey)
                .FirstOrDefaultAsync(t => t.Symbol == symbol);
        }
    }
}
