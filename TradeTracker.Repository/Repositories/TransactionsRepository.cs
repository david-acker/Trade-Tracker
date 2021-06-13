using Dapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.EntityModels.Models.Transaction;
using TradeTracker.Repository.Factories;

namespace TradeTracker.Repository.Repositories
{
    public interface ITransactionsRepository
    {
        Task<Transaction> GetAsync(int transactionId, string accessKey);
        Task<Transaction> CreateAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(int transactionId, string accessKey);
    }
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public TransactionsRepository(IConnectionFactory connectionFactory)
{
            _connectionFactory = connectionFactory;
        }

        public async Task<Transaction> GetAsync(int transactionId, string accessKey)
        {
            var sql = @$"SELECT * FROM [Transaction] WHERE TransactionId = @TransactionId AND AccessKey = @AccessKey";

            var parameters = new DynamicParameters();
            parameters.Add("@TransactionId", transactionId);
            parameters.Add("@AccessKey", accessKey);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<Transaction>(sql, parameters);
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AccessKey", transaction.AccessKey);
            parameters.Add("@Symbol", transaction.Symbol);
            parameters.Add("@TradeDate", transaction.TradeDate);
            parameters.Add("@TradePrice", transaction.TradePrice);
            parameters.Add("@Quantity", transaction.Quantity);
            parameters.Add("@Notional", transaction.Notional);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            var result = await connection.QueryAsync<Transaction>(
                "StoCreateTransaction",
                parameters,
                commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TransactionId", transaction.TransactionId);
            parameters.Add("@AccessKey", transaction.AccessKey);
            parameters.Add("@Symbol", transaction.Symbol);
            parameters.Add("@TradeDate", transaction.TradeDate);
            parameters.Add("@TradePrice", transaction.TradePrice);
            parameters.Add("@Quantity", transaction.Quantity);
            parameters.Add("@Notional", transaction.Notional);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            await connection.QueryAsync(
                "StoUpdateTransaction",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteAsync(int transactionId, string accessKey)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TransactionId", transactionId);
            parameters.Add("@AccessKey", accessKey);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            await connection.QueryAsync(
                "StoDeleteTransaction",
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
