using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Enums;
using TradeTracker.Application.Interfaces.Persistence.Positions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
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
            var query = (IQueryable<Position>)_context.Positions;

            return await query.ForAccessKey(accessKey)
                .Where(p => p.Symbol == symbol)
                .FirstOrDefaultAsync();
        }

        public override async Task<PagedList<Position>> GetPagedResponseAsync(
            PagedPositionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = (IQueryable<Position>)_context.Positions;
        
            query = query.ForAccessKey(accessKey);

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

            query = query.ForExposureType(parameters.Exposure);

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

        public override async Task<IEnumerable<Position>> GetUnpagedResponseAsync(
            UnpagedPositionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = (IQueryable<Position>)_context.Positions;
        
            query = query.ForAccessKey(accessKey);

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

            query = query.ForExposureType(parameters.Exposure);

            var intermediateResults = await query.ToListAsync();

            // Temporary workaround for OrderBy clauses on Decimal types (Quantity) while using SQLite,
            // which does not support Decimal types with OrderBy. Will be removed upon conversion to SQL Server.
            
            IList<Position> orderedPositions;
            switch (parameters.SortOrder.Field)
            {
                case "Quantity":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedPositions = intermediateResults
                            .OrderBy(t => t.Quantity)
                            .ToList();
                    else
                        orderedPositions = intermediateResults
                            .OrderByDescending(t => t.Quantity)
                            .ToList();

                    intermediateResults.Clear();
                    intermediateResults.AddRange(orderedPositions);
                    break;

                default:
                    break;
            }

            return intermediateResults;
        }
    }
}
