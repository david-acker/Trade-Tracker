using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Domain.Entities;
using TradeTracker.Persistence.Extensions;

namespace TradeTracker.Persistence.Repositories
{
    public class TransactionRepository : 
        BaseRepository<Transaction, PagedTransactionsResourceParameters, UnpagedTransactionsResourceParameters>, 
        ITransactionRepository
    {
        public TransactionRepository(
            TradeTrackerDbContext context) : base(context)
        {
        }

        public override async Task<PagedList<Transaction>> GetPagedResponseAsync(
            PagedTransactionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = _context.Transactions
                .ForTransactionType(parameters.TransactionType)
                .ForSymbolSelection(parameters.SymbolSelection)
                .ForRangeStart(parameters.RangeStart)
                .ForRangeEnd(parameters.RangeEnd)
                .ForOrderBy(parameters.OrderBy);        

            return await PagedList<Transaction>.CreateAsync(
                query, parameters.PageNumber, parameters.PageSize);
        }

        public override async Task<IEnumerable<Transaction>> GetUnpagedResponseAsync(
            UnpagedTransactionsResourceParameters parameters,
            Guid accessKey)
        {
            return await _context.Transactions
                .ForAccessKey(accessKey)
                .ForTransactionType(parameters.TransactionType)
                .ForSymbolSelection(parameters.SymbolSelection)
                .ForRangeStart(parameters.RangeStart)
                .ForRangeEnd(parameters.RangeEnd)
                .ForOrderBy(parameters.OrderBy)
                .ToListAsync();  
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
