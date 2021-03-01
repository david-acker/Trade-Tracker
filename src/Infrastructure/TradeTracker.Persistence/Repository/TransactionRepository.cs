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

        public override async Task<Transaction> GetByIdAsync(string accessKey, Guid id)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessKey == accessKey)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
        }

        public override async Task<IReadOnlyList<Transaction>> ListAllAsync(string accessKey)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessKey == accessKey)
                .ToListAsync();
        }

        public async Task<PagedList<Transaction>> GetPagedTransactionsList(string accessKey, int page, int size)
        {
            var transactionsQuery = _dbContext.Transactions
                .Where(t => t.AccessKey == accessKey);

            return await PagedList<Transaction>.CreateAsync(transactionsQuery, page, size);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionCollectionByIds(string accessKey, IEnumerable<Guid> ids)
        {
            return await _dbContext.Transactions
                .Where(t => t.AccessKey == accessKey && ids.Contains(t.TransactionId))
                .ToListAsync();
        }
    }
}
