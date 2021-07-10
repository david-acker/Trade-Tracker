using System.Threading.Tasks;
using TradeTracker.Core.DomainModels.Response;
using TradeTracker.Core.DomainModels.Transaction;

namespace TradeTracker.Business.Interfaces.Infrastructure
{
    public interface ITransactionsRepository
    {
        Task<TransactionDomainModel> GetAsync(int transactionId, string accessKey);
        Task<PaginatedResult<TransactionDomainModel>> GetFilteredAsync(TransactionFilterDomainModel filterModel, string accessKey);
        Task<TransactionDomainModel> CreateAsync(TransactionDomainModel transaction);
        Task UpdateAsync(TransactionDomainModel transaction);
        Task DeleteAsync(int transactionId, string accessKey);
    }
}
