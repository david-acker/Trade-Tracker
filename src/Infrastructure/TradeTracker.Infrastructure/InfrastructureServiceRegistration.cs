using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Application.Interfaces.Infrastructure;

namespace TradeTracker.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
