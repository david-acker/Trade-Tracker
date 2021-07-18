using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Business.Interfaces.Infrastructure;
using TradeTracker.Repository.Factories;
using TradeTracker.Repository.Options;
using TradeTracker.Repository.Repositories;

namespace TradeTracker.Repository
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(
                configuration.GetSection(DatabaseOptions.Database));

            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();
            services.AddScoped<IPositionsRepository, PositionsRepository>();

            return services;
        }
    }
}
