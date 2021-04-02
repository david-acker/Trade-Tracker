using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Application.Interfaces.Persistence.Positions;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Persistence.Repositories;

namespace TradeTracker.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TradeTrackerDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("TradeTrackerConnectionString"));
            });
                
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAuthenticatedTransactionRepository, AuthenticatedTransactionRepository>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IAuthenticatedPositionRepository, AuthenticatedPositionRepository>();

            return services;    
        }
    }
}
