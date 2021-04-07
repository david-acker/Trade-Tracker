using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;
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

        public override async Task<Transaction> AddAsync(Transaction transaction)
        {
            transaction.DomainEvents.Add(
                new TransactionCreatedEvent(transaction));
            
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public override async Task<IEnumerable<Transaction>> AddRangeAsync(
            IEnumerable<Transaction> transactionCollection)
        {
            var lastTransaction = transactionCollection.Last();
            lastTransaction.DomainEvents.Add(
                new TransactionCollectionCreatedEvent(transactionCollection));

            _context.Transactions.AddRange(transactionCollection);
            await _context.SaveChangesAsync();

            return transactionCollection;
        }

        public override async Task UpdateAsync(Transaction transaction)
        {
            var originalTransaction = await _context.Transactions
                .ForAccessKey(transaction.AccessKey)
                .Where(t => t.Id == transaction.Id)
                .FirstOrDefaultAsync();
            
            transaction.DomainEvents.Add(
                new TransactionModifiedEvent(originalTransaction));
        
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Transaction transaction)
        {
            transaction.DomainEvents.Add(
                new TransactionDeletedEvent(transaction));

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public override async Task<PagedList<Transaction>> GetPagedResponseAsync(
            PagedTransactionsResourceParameters parameters,
            Guid accessKey)
        {
            var query = _context.Transactions
                .ForAccessKey(accessKey)
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
                .Where(t => ids.Contains(t.Id))
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
