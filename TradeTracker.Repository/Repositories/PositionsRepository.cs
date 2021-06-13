using Dapper;
using System.Threading.Tasks;
using TradeTracker.EntityModels.Models.Position;
using TradeTracker.Repository.Factories;

namespace TradeTracker.Repository.Repositories
{
    public interface IPositionsRepository
    {
        Task<Position> GetAsync(string symbol, string accessKey);
    }
    public class PositionsRepository : IPositionsRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PositionsRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Position> GetAsync(string symbol, string accessKey)
        {
            var sql = $@"SELECT * FROM [Position] WHERE Symbol = @Symbol AND AccessKey = @AccessKey";

            var parameters = new DynamicParameters();
            parameters.Add("@Symbol", symbol);
            parameters.Add("@AccessKey", accessKey);

            using var connection = _connectionFactory.NewConnection();
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<Position>(sql, parameters);
        }
    }
}
