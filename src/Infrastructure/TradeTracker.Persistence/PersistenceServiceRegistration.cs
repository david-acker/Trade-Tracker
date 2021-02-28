using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Persistence.Repositories;

namespace TradeTracker.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TradeTrackerDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("TradeTrackerConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;    
        }
    }
}
