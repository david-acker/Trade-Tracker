using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Business.Helpers;
using TradeTracker.Business.Services;

namespace TradeTracker.Business
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeHelper, DateTimeHelper>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            return services;
        }
    }
}
