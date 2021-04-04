using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Persistence.Repositories;

namespace TradeTracker.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDbContext<TradeTrackerDbContext>(options =>
            // {
            //     options.UseSqlite(configuration.GetConnectionString("TradeTrackerSqliteConnectionString"));
            // });

            services.AddDbContext<TradeTrackerDbContext>(options => 
            {
                options.UseNpgsql(configuration.GetConnectionString("TradeTrackerPostgresConnectionString"));
            });
                
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAuthenticatedTransactionRepository, AuthenticatedTransactionRepository>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IAuthenticatedPositionRepository, AuthenticatedPositionRepository>();

            return services;    
        }
    }
}
