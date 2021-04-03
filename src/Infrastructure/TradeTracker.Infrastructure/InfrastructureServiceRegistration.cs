using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Infrastructure.Services;

namespace TradeTracker.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionTrackingService, PositionTrackingService>();

            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
