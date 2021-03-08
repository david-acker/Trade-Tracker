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

        public async Task<PagedList<Transaction>> GetPagedTransactionsListAsync(GetPagedTransactionsResourceParameters resourceParameters)
        {
            var query = (IQueryable<Transaction>)_context.Transactions;
        
            query = query.Where(t => t.AccessKey == resourceParameters.AccessKey);

            if (resourceParameters.Including.Count > 0)
            {
                var inclusionSelection = resourceParameters.Including;
                query = query.Where(t => inclusionSelection.Any(x => x == t.Symbol));
            }

            if (resourceParameters.Excluding.Count > 0)
            {
                var exclusionSelection = resourceParameters.Excluding;
                query = query.Where(t => !exclusionSelection.Any(x => x == t.Symbol));
            }

            if (resourceParameters.RangeStart != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime > resourceParameters.RangeStart));
            }

            if (resourceParameters.RangeEnd != DateTime.MaxValue && 
                resourceParameters.RangeEnd != DateTime.MinValue)
            {
                query = query.Where(t => (t.DateTime < resourceParameters.RangeEnd));
            }
            
            switch (resourceParameters.OrderBy)
            {
                case "Symbol":
                    query = query.OrderBy(t => t.Symbol);
                    break;

                case "Quantity":
                    query = query.OrderByDescending(t => t.Quantity);
                    break;

                case "Notional":
                    query = query.OrderByDescending(t => t.Notional);
                    break;

                case "DateTime":
                default:
                    query = query.OrderByDescending(t => t.DateTime);
                    break;
            }

            return await PagedList<Transaction>.CreateAsync(query, resourceParameters.PageNumber, resourceParameters.PageSize);
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
