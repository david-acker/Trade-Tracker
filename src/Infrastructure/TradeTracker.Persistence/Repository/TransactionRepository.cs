using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(TradeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Transaction> GetByIdAsync(string accessTag, Guid id)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessTag == accessTag)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
        }

        public override async Task<IReadOnlyList<Transaction>> ListAllAsync(string accessTag)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessTag == accessTag)
                .ToListAsync();
        }

        public async Task<PagedList<Transaction>> GetPagedTransactionsList(string accessTag, int page, int size)
        {
            var transactionsQuery = _dbContext.Transactions
                .Where(t => t.AccessTag == accessTag);

            return await PagedList<Transaction>.CreateAsync(transactionsQuery, page, size);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionCollectionByIds(string accessTag, IEnumerable<Guid> ids)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessTag == accessTag && ids.Contains(t.TransactionId))
                .ToListAsync();
        }
    }
}
