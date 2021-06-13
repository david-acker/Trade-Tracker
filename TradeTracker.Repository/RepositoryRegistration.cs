using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Repository.Factories;
using TradeTracker.Repository.Repositories;

namespace TradeTracker.Repository
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            return services;
        }
    }
}
