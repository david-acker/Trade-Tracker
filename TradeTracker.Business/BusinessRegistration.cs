using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Business.Services;

namespace TradeTracker.Business
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IPositionService, PositionService>();

            return services;
        }
    }
}
