using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Enums;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Persistence.Extensions;

namespace TradeTracker.Persistence.Repositories
{
    public class TransactionRepository : 
        BaseRepository<Transaction, PagedPositionsResourceParameters, UnpagedTransactionsResourceParameters>, 
        ITransactionRepository
    {
        public TransactionRepository(
            TradeTrackerDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Transaction>> GetPagedResponseAsync(
            PagedTransactionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = (IQueryable<Transaction>)_context.Transactions;
        
            query = query
                .ForAccessKey(accessKey)
                .ForTransactionType(parameters.Type);

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

            if (parameters.RangeStart != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime > parameters.RangeStart));
            }

            if (parameters.RangeEnd != DateTime.MaxValue && 
                parameters.RangeEnd != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime < parameters.RangeEnd));
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

                case "Notional":
                    // query = query.OrderByDescending(t => t.Notional);
                    break;

                case "DateTime":
                default:
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        query = query.OrderBy(t => t.DateTime);
                    else
                        query = query.OrderByDescending(t => t.DateTime);
                    break;
            }            

            var pagedTransactions = await PagedList<Transaction>.CreateAsync(
                query, parameters.PageNumber, parameters.PageSize);

            // Temporary workaround for OrderBy clauses on Decimal types (Quantity, Notional) while using SQLite,
            // which does not support Decimal types with OrderBy. Will be removed upon conversion to SQL Server.
            IList<Transaction> orderedTransactions;
            switch (parameters.SortOrder.Field)
            {
                case "Quantity":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedTransactions = pagedTransactions
                            .OrderBy(t => t.Quantity)
                            .ToList();
                    else
                        orderedTransactions = pagedTransactions
                            .OrderByDescending(t => t.Quantity)
                            .ToList();

                    pagedTransactions.Clear();
                    pagedTransactions.AddRange(orderedTransactions);
                    break;

                case "Notional":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedTransactions = pagedTransactions
                            .OrderBy(t => t.Notional)
                            .ToList();
                    else
                        orderedTransactions = pagedTransactions
                            .OrderByDescending(t => t.Notional)
                            .ToList();
                    
                    pagedTransactions.Clear();
                    pagedTransactions.AddRange(orderedTransactions);
                    break;

                default:
                    break;
            }

            return pagedTransactions;
        }

        public override async Task<IEnumerable<Transaction>> GetUnpagedResponseAsync(
            UnpagedTransactionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = (IQueryable<Transaction>)_context.Transactions;
        
            query = query
                .ForAccessKey(accessKey)
                .ForTransactionType(parameters.Type);

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

            if (parameters.RangeStart != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime > parameters.RangeStart));
            }

            if (parameters.RangeEnd != DateTime.MaxValue && 
                parameters.RangeEnd != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime < parameters.RangeEnd));
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

                case "Notional":
                    // query = query.OrderByDescending(t => t.Notional);
                    break;

                case "DateTime":
                default:
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        query = query.OrderBy(t => t.DateTime);
                    else
                        query = query.OrderByDescending(t => t.DateTime);
                    break;
            }            

            var intermediateResults = await query.ToListAsync();

            // Temporary workaround for OrderBy clauses on Decimal types (Quantity, Notional) while using SQLite,
            // which does not support Decimal types with OrderBy. Will be removed upon conversion to SQL Server.
            IList<Transaction> orderedTransactions;
            switch (parameters.SortOrder.Field)
            {
                case "Quantity":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedTransactions = intermediateResults
                            .OrderBy(t => t.Quantity)
                            .ToList();
                    else
                        orderedTransactions = intermediateResults
                            .OrderByDescending(t => t.Quantity)
                            .ToList();

                    intermediateResults.Clear();
                    intermediateResults.AddRange(orderedTransactions);
                    break;

                case "Notional":
                    if (parameters.SortOrder.Type == SortOrderType.Ascending)
                        orderedTransactions = intermediateResults
                            .OrderBy(t => t.Notional)
                            .ToList();
                    else
                        orderedTransactions = intermediateResults
                            .OrderByDescending(t => t.Notional)
                            .ToList();
                    
                    intermediateResults.Clear();
                    intermediateResults.AddRange(orderedTransactions);
                    break;

                default:
                    break;
            }

            return intermediateResults;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(
            IEnumerable<Guid> ids,
            Guid accessKey)
        {
            return await _context.Transactions
                .ForAccessKey(accessKey)
                .Where(t => ids.Contains(t.TransactionId))
                .ToListAsync();
        }
        
        public HashSet<string> GetSetOfSymbolsForAllTransactionsByUser(
            Guid accessKey)
        {
            return _context.Transactions
                .ForAccessKey(accessKey)
                .Select(t => t.Symbol)
                .ToHashSet();
        }
    }
}
