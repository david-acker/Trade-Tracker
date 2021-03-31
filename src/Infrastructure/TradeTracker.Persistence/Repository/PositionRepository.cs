using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Enums;
using TradeTracker.Application.Features.Positions.Queries.GetPositions;
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

        public async Task<PagedList<Position>> GetPagedPositionsAsync(
            Guid userAccessKey, 
            PagedPositionsResourceParameters parameters)
        {
            var query = (IQueryable<Position>)_context.Positions;
        
            query = query.Where(t => t.AccessKey == userAccessKey);

            if (parameters.Selection != null)
            {
                List<string> selection = parameters.Selection.Values;

                switch (parameters.Selection.Type)
                {
                    case SelectionType.Include:
                        query = query.Where(t => selection.Any(x => x == t.Symbol));
                        break;

                    case SelectionType.Exclude:
                        query = query.Where(t => !selection.Any(x => x == t.Symbol));
                        break;

                    default:
                        break;
                }
            }
            
            switch (parameters.SortOrder.Field)
            {
                case "Symbol":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        query = query.OrderBy(t => t.Symbol);
                    else
                        query = query.OrderByDescending(t => t.Symbol);
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
            switch (parameters.SortOrder.Field)
            {
                case "Quantity":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedPositions = pagedPositions
                            .OrderBy(t => t.Quantity)
                            .ToList();
                    else
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
