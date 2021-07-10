using AutoMapper;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Core.DomainModels.Response;
using TradeTracker.Core.DomainModels.Transaction;
using TradeTracker.Repository.EntityModels.Transaction;
using TradeTracker.Repository.Factories;
using TradeTracker.Repository.Helpers;

namespace TradeTracker.Repository.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;

        public TransactionsRepository(
            IConnectionFactory connectionFactory,
            IMapper mapper)
{
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        public async Task<TransactionDomainModel> GetAsync(int transactionId, string accessKey)
        {
            var sql = @$"SELECT * FROM [Transaction] WHERE TransactionId = @TransactionId AND AccessKey = @AccessKey";

            var parameters = new DynamicParameters();
            parameters.Add("@TransactionId", transactionId);
            parameters.Add("@AccessKey", accessKey);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            var transaction = await connection.QueryFirstOrDefaultAsync<TransactionEntityModel>(sql, parameters);

            return _mapper.Map<TransactionDomainModel>(transaction);
        }

        public async Task<PaginatedResult<TransactionDomainModel>> GetFilteredAsync(TransactionFilterDomainModel filterModel, string accessKey)
        {
            var filterEntityModel = _mapper.Map<TransactionFilterEntityModel>(filterModel);
            filterEntityModel.AccessKey = accessKey;

            var parameters = CreateParametersForGetFilteredAsync(filterEntityModel);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            var reader = await connection.QueryMultipleAsync(
                "StoGetFilteredTransactions",
                parameters,
                commandType: CommandType.StoredProcedure);

            var transactions = reader.Read<TransactionEntityModel>().ToList();
            var totalRecordCount = reader.Read<int>().SingleOrDefault();

            return new PaginatedResult<TransactionDomainModel>(
                results: _mapper.Map<IEnumerable<TransactionDomainModel>>(transactions),
                metadata: CreatePaginationMetadata(filterEntityModel, totalRecordCount));
        }

        private DynamicParameters CreateParametersForGetFilteredAsync(TransactionFilterEntityModel filterModel)
        {
            var skip = PaginationHelper.CalculateSkip(filterModel);
            var take = PaginationHelper.CalculateTake(filterModel);

            var parameters = new DynamicParameters();
            parameters.Add("@AccessKey", filterModel.AccessKey);
            parameters.Add("@Skip", skip);
            parameters.Add("@Take", take);
            parameters.Add("@StartDate", filterModel.StartDate);
            parameters.Add("@EndDate", filterModel.EndDate);
            parameters.Add("@Symbol", filterModel.Symbol);
            parameters.Add("@TransactionType", filterModel.TransactionType);
            parameters.Add("@OrderByField", filterModel.OrderByField);
            parameters.Add("@OrderByDirection", filterModel.OrderByDirection);

            return parameters;
        }

        private PaginationMetadata CreatePaginationMetadata(TransactionFilterEntityModel filterModel, int totalRecordCount)
        {
            var metadata = new PaginationMetadata
            {
                Page = filterModel.Page,
                PageSize = filterModel.PageSize,
                TotalPages = PaginationHelper.CalculateTotalPages(filterModel, totalRecordCount),
                TotalRecordCount = totalRecordCount
            };

            return metadata;
        }

        public async Task<TransactionDomainModel> CreateAsync(TransactionDomainModel transaction)
        {
            var transactionEntityModel = _mapper.Map<TransactionEntityModel>(transaction);

            var parameters = CreateParametersForCreateAynsc(transactionEntityModel);
            
            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            var result = await connection.QueryAsync<TransactionEntityModel>(
                "StoCreateTransaction",
                parameters,
                commandType: CommandType.StoredProcedure);
            
            return _mapper.Map<TransactionDomainModel>(result.SingleOrDefault());
        }

        private DynamicParameters CreateParametersForCreateAynsc(TransactionEntityModel transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AccessKey", transaction.AccessKey);
            parameters.Add("@Symbol", transaction.Symbol);
            parameters.Add("@TradeDate", transaction.TradeDate);
            parameters.Add("@TradePrice", transaction.TradePrice);
            parameters.Add("@Quantity", transaction.Quantity);
            parameters.Add("@Notional", transaction.Notional);

            return parameters;
        }

        public async Task UpdateAsync(TransactionDomainModel transaction)
        {
            var transactionEntityModel = _mapper.Map<TransactionEntityModel>(transaction);

            var parameters = CreateParametersForUpdateAsync(transactionEntityModel);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            await connection.QueryAsync(
                "StoUpdateTransaction",
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        private DynamicParameters CreateParametersForUpdateAsync(TransactionEntityModel transaction)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TransactionId", transaction.TransactionId);
            parameters.Add("@AccessKey", transaction.AccessKey);
            parameters.Add("@Symbol", transaction.Symbol);
            parameters.Add("@TradeDate", transaction.TradeDate);
            parameters.Add("@TradePrice", transaction.TradePrice);
            parameters.Add("@Quantity", transaction.Quantity);
            parameters.Add("@Notional", transaction.Notional);

            return parameters;
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
