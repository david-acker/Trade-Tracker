using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Transactions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Interfaces;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Persistence.Repositories
{
    public class AuthenticatedTransactionRepository : IAuthenticatedTransactionRepository
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ITransactionRepository _transactionRepository;

        public AuthenticatedTransactionRepository(
            ILoggedInUserService loggedInUserService,
            ITransactionRepository transactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _transactionRepository = transactionRepository;
        }

        private Guid GetAccessKey()
        {
            if ((bool)_loggedInUserService?.IsLoggedIn())
                return _loggedInUserService.AccessKey;
            else
                throw new UnauthorizedAccessException("The current session has expired. Please reload and log back in.");
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            transaction.AccessKey = GetAccessKey();

            return await _transactionRepository.AddAsync(transaction);
        }

        public async Task<IEnumerable<Transaction>> AddRangeAsync(
            IEnumerable<Transaction> transactionCollection)
        {
            var accessKey = GetAccessKey();

            transactionCollection = transactionCollection
                .Select(transaction => 
                {
                    transaction.AccessKey = accessKey;
                    return transaction;
                });

            return await _transactionRepository.AddRangeAsync(transactionCollection); 
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            transaction.AccessKey = GetAccessKey();

            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task DeleteAsync(Transaction transaction)
        {
            transaction.AccessKey = GetAccessKey();

            await _transactionRepository.DeleteAsync(transaction);
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _transactionRepository
                .GetByIdAsync(id, GetAccessKey());
        }

        public async Task<PagedList<Transaction>> GetPagedResponseAsync(
            PagedTransactionsResourceParameters parameters)
        {
            return await _transactionRepository
                .GetPagedResponseAsync(parameters, GetAccessKey());
        }

        public async Task<IEnumerable<Transaction>> GetUnpagedResponseAsync(
            UnpagedTransactionsResourceParameters parameters)
        {
            return await _transactionRepository
                .GetUnpagedResponseAsync(parameters, GetAccessKey());
        }

        public HashSet<string> GetSetOfSymbolsForAllTransactionsByUser()
        {
            return _transactionRepository
                .GetSetOfSymbolsForAllTransactionsByUser(GetAccessKey());
        }

        public async Task<IEnumerable<Transaction>> GetTransactionCollectionByIdsAsync(
            IEnumerable<Guid> ids)
        {
            return await _transactionRepository
                .GetTransactionCollectionByIdsAsync(ids, GetAccessKey());
        }
    }
}