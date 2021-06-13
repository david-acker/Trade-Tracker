using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using TradeTracker.Business.Helpers;
using TradeTracker.Core.DomainModels;
using TradeTracker.EntityModels.Models.Transaction;
using TradeTracker.Repository.Repositories;

namespace TradeTracker.Business.Services
{
    public interface ITransactionsService
    {
        Task<Transaction> GetTransaction(int transactionId, string accessKey);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int transactionId, string accessKey);
        ModelStateDictionary ValidateTransaction(TransactionInputDomainModel inputModel);
    }
    
    public class TransactionsService : ITransactionsService
    {
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionsService(
            ITransactionsRepository transactionsRepository,
            IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
            _transactionsRepository = transactionsRepository;
        }

        public async Task<Transaction> GetTransaction(int transactionId, string accessKey)
        {
            return await _transactionsRepository.GetAsync(transactionId, accessKey);
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            return await _transactionsRepository.CreateAsync(transaction);
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            await _transactionsRepository.UpdateAsync(transaction);
        }

        public async Task DeleteTransaction(int transactionId, string accessKey)
        {
            await _transactionsRepository.DeleteAsync(transactionId, accessKey);
        }

        public ModelStateDictionary ValidateTransaction(TransactionInputDomainModel inputModel)
        {
            var errors = new ModelStateDictionary();

            if (string.IsNullOrWhiteSpace(inputModel.Symbol))
            {
                errors.AddModelError("Symbol", "A symbol is required for the transaction.");
            }

            if (!_dateTimeHelper.HasDateTimeAlreadyOccurred(inputModel.TradeDate))
            {
                errors.AddModelError("TradeDate", "The transaction must have already occurred.");
            }

            if (inputModel.TradePrice <= decimal.Zero)
            {
                errors.AddModelError("TradePrice", "The trade price must be greater than zero.");
            }

            if (inputModel.Quantity <= decimal.Zero)
            {
                errors.AddModelError("Quantity", "The quantity must be greater than zero.");
            }

            if (inputModel.Notional <= decimal.Zero)
            {
                errors.AddModelError("Notional", "The notional must be greater than zero.");
            }

            return errors;
        }
    }
}
