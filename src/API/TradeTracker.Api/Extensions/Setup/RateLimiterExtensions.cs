using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TradeTracker.Api.Extensions.Setup
{
    public static class RateLimiterExtensions
    {
        public static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            
            services.Configure<IpRateLimitOptions>(
                configuration.GetSection("IpRateLimiting"));
            
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            
            services.AddHttpContextAccessor();

            return services;
        }
    }
}