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
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(TradeTrackerDbContext context) : base(context)
        {
        }

        public override async Task<Transaction> GetByIdAsync(Guid accessKey, Guid id)
        {
            return await _context.Transactions
                .Where(t => t.AccessKey == accessKey)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
        }

        public override async Task<IReadOnlyList<Transaction>> ListAllAsync(Guid accessKey)
        {
            return await _context.Transactions
                .Where(t => t.AccessKey == accessKey)
                .ToListAsync();
        }

        public async Task<PagedList<Transaction>> GetPagedTransactionsAsync(PagedTransactionsResourceParameters parameters)
        {
            var query = (IQueryable<Transaction>)_context.Transactions;
        
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

            if (parameters.RangeStart != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime > parameters.RangeStart));
            }

            if (parameters.RangeEnd != DateTime.MaxValue && 
                parameters.RangeEnd != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime < parameters.RangeEnd));
            }
            
            switch (parameters.OrderBy)
            {
                case "Symbol":
                    query = query.OrderBy(t => t.Symbol);
                    break;

                case "Quantity":
                    // query = query.OrderByDescending(t => t.Quantity);
                    break;

                case "Notional":
                    // query = query.OrderByDescending(t => t.Notional);
                    break;

                case "DateTime":
                default:
                    query = query.OrderByDescending(t => t.DateTime);
                    break;
            }            

            var pagedTransactions = await PagedList<Transaction>.CreateAsync(query, parameters.PageNumber, parameters.PageSize);

            // Temporary workaround for OrderBy clauses on Decimal types (Quantity, Notional) while using SQLite,
            // which does not support Decimal types with OrderBy. Will be removed upon conversion to SQL Server.
            IList<Transaction> orderedTransactions;
            switch (parameters.OrderBy)
            {
                case "Quantity":
                    orderedTransactions = pagedTransactions
                        .OrderByDescending(t => t.Quantity)
                        .ToList();

                    pagedTransactions.Clear();
                    pagedTransactions.AddRange(orderedTransactions);
                    break;

                case "Notional":
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

        public async Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(Guid accessKey, IEnumerable<Guid> ids)
        {
            return await _context.Transactions
                .Where(t => t.AccessKey == accessKey && ids.Contains(t.TransactionId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsForSymbolAsync(Guid accessKey, string symbol)
        {
            return await _context.Transactions
                .Where(t => t.AccessKey == accessKey && t.Symbol == symbol)
                .OrderByDescending(t => t.DateTime)
                .ToListAsync();
        }

        public HashSet<string> GetSetOfSymbolsForAllTransactionsByUser(Guid accessKey)
        {
            return _context.Transactions
                .Where(t => t.AccessKey == accessKey)
                .Select(t => t.Symbol)
                .ToHashSet();
        }
    }
}
