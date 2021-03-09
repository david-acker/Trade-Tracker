using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
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

        public async Task<PagedList<Position>> GetPagedPositionsAsync(PagedPositionsResourceParameters parameters)
        {
            var query = (IQueryable<Position>)_context.Positions;
        
            query = query.Where(t => t.AccessKey == parameters.AccessKey);

            if (parameters.Including.Count > 0)
            {
                var inclusionSelection = parameters.Including;
                query = query.Where(t => inclusionSelection.Any(x => x == t.Symbol));
            }

            if (parameters.Excluding.Count > 0)
            {
                var exclusionSelection = parameters.Excluding;
                query = query.Where(t => !exclusionSelection.Any(x => x == t.Symbol));
            }
            
            switch (parameters.OrderBy)
            {
                case "Symbol":
                    query = query.OrderBy(t => t.Symbol);
                    break;

                case "Quantity":
                    // query = query.OrderByDescending(t => t.Quantity);
                    break;
            }

            switch (parameters.Exposure)
            {
                case "Long":
                    query = query.Where(t => t.Exposure == "Long");
                    break;
                
                case "Short":
                    query = query.Where(t => t.Exposure == "Short");
                    break;

                default:
                    break;
            }

            var pagedPositions = await PagedList<Position>.CreateAsync(query, parameters.PageNumber, parameters.PageSize);

            // Temporary workaround for OrderBy clauses on Decimal types (Quantity) while using SQLite,
            // which does not support Decimal types with OrderBy. Will be removed upon conversion to SQL Server.
            
            IList<Position> orderedPositions;
            switch (parameters.OrderBy)
            {
                case "Quantity":
                    orderedPositions = pagedPositions
                        .OrderByDescending(t => t.Quantity)
                        .ToList();

                    pagedPositions.Clear();
                    pagedPositions.AddRange(orderedPositions);
                    break;

                default:
                    break;
            }

            return pagedPositions;
        }
    }
}
