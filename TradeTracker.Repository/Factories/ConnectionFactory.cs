using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using TradeTracker.Repository.Options;

namespace TradeTracker.Repository.Factories
{
    public interface IConnectionFactory
    {
        SqlConnection NewConnection();
    }

    public class ConnectionFactory : IConnectionFactory
    {
        private readonly DatabaseOptions _databaseOptions;

        public ConnectionFactory(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
        }

        public SqlConnection NewConnection()
        {
            return new SqlConnection(_databaseOptions.ConnectionString);
        }
    }
}
