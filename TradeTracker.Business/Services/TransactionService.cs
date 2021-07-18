using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Business.AuxiliaryModels;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Core.DomainModels.Transaction;

namespace TradeTracker.Business.Services
{
    public interface ITransactionService
    {
        Task<TransactionDomainModel> GetTransaction(int transactionId, string accessKey);
        Task<PaginatedResult<TransactionDomainModel>> GetFilteredTransactions(TransactionFilterDomainModel filterModel, string accessKey);
        Task<TransactionDomainModel> CreateTransaction(TransactionDomainModel transaction);
        Task UpdateTransaction(TransactionDomainModel transaction);
        Task DeleteTransaction(TransactionDomainModel transaction);
        ModelStateDictionary ValidateTransaction(TransactionDomainModel inputModel);
        ModelStateDictionary ValidateTransactionFilterModel(TransactionFilterDomainModel filterModel);
    }
    
    public class TransactionService : ITransactionService
    {
        private readonly IDateTimeService _dateTimeHelper;
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionService(
            ITransactionsRepository transactionsRepository,
            IDateTimeService dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
            _transactionsRepository = transactionsRepository;
        }

        public async Task<TransactionDomainModel> GetTransaction(int transactionId, string accessKey)
        {
            return await _transactionsRepository.GetAsync(transactionId, accessKey);
        }

        public async Task<PaginatedResult<TransactionDomainModel>> GetFilteredTransactions(TransactionFilterDomainModel filterModel, string accessKey)
        {
            return await _transactionsRepository.GetFilteredAsync(filterModel, accessKey);
        }

        public async Task<TransactionDomainModel> CreateTransaction(TransactionDomainModel transaction)
        {
            return await _transactionsRepository.CreateAsync(transaction);
        }

        public async Task UpdateTransaction(TransactionDomainModel transaction)
        {
            await _transactionsRepository.UpdateAsync(transaction);
        }

        public async Task DeleteTransaction(TransactionDomainModel transaction)
        {
            await _transactionsRepository.DeleteAsync(transaction.TransactionId, transaction.AccessKey);
        }

        public ModelStateDictionary ValidateTransaction(TransactionDomainModel inputModel)
        {
            var errors = new ModelStateDictionary();

            if (string.IsNullOrWhiteSpace(inputModel.Symbol))
            {
                errors.AddModelError("Symbol", "A symbol is required for the transaction.");
            }

            if (inputModel.TradeDate == default)
            {
                errors.AddModelError("TradeDate", "A trade date is required for the transaction.");
            } 
            else if (!_dateTimeHelper.HasDateTimeAlreadyOccurred(inputModel.TradeDate))
            {
                errors.AddModelError("TradeDate", "The transaction must have already occurred.");
            }

            if (inputModel.TradePrice <= decimal.Zero)
            {
                errors.AddModelError("TradePrice", "The trade price must be greater than zero.");
            }

            if (inputModel.Quantity == decimal.Zero)
            {
                errors.AddModelError("Quantity", "The quantity cannot be equal to zero.");
            }

            if (inputModel.Notional == decimal.Zero)
            {
                errors.AddModelError("Notional", "The notional cannot be equal to zero.");
            }

            return errors;
        }

        public ModelStateDictionary ValidateTransactionFilterModel(TransactionFilterDomainModel filterModel)
        {
            var errors = new ModelStateDictionary();

            if (filterModel.Page < 1)
            {
                errors.AddModelError("Page", "The page number cannot be less than one.");
            }

            if (filterModel.PageSize < 1)
            {
                errors.AddModelError("PageSize", "The page size cannot be less than 1.");
            }

            if (filterModel.StartDate.HasValue && filterModel.EndDate.HasValue)
            {
                if (filterModel.StartDate.Value >= filterModel.EndDate.Value)
                {
                    errors.AddModelError("StartDate", "The start date must occur before the end date.");
                }
            }

            if (!string.IsNullOrEmpty(filterModel.Symbol) && filterModel.Symbol.Length > 10)
            {
                errors.AddModelError("Symbol", "The provided symbol must not exceed 10 characters.");
            }

            if (filterModel.TransactionType.HasValue)
            {
                char inputTransactionType = filterModel.TransactionType.Value;

                var validTransactionTypes = new char[] { 'B', 'S' };

                if (!validTransactionTypes.Contains(inputTransactionType))
                {
                    errors.AddModelError("TransactionType", "The transaction type must be a valid type: B - Buy, S - Sell.");
                }
            }

            if (!string.IsNullOrEmpty(filterModel.OrderByField))
            {
                string inputOrderByField = filterModel.OrderByField;

                var validOrderByFields = new string[]
                {
                    "TransactionId",
                    "Symbol",
                    "TradeDate",
                    "TradePrice",
                    "Quantity",
                    "Notional"
                };

                if (!validOrderByFields.Select(x => x.ToLower())
                                       .Contains(inputOrderByField.ToLower()))
                {
                    errors.AddModelError("OrderByField", $"The order by field must be a valid field: {string.Join(", ", validOrderByFields)}.");
                }
            }

            if (filterModel.OrderByDirection.HasValue)
            {
                char inputOrderByDirection = filterModel.OrderByDirection.Value;

                var validOrderByDirections = new char[] { 'A', 'D' };

                if (!validOrderByDirections.Contains(inputOrderByDirection))
                {
                    errors.AddModelError("OrderByDirection", "The order by direction must be a valid direction: A - Ascending, D - Descending.");
                }
            }

            return errors;
        }
    }
}
