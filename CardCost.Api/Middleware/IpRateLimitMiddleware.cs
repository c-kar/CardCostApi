using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardCost.Api.Middleware
{
    public static class IpRateLimitMiddleware
    {
        public static IServiceCollection AddIpRateLimitMiddleware(this IServiceCollection services, IConfiguration _configuration)
        {
            services
                .AddOptions()
                .AddMemoryCache()
                .Configure<IpRateLimitOptions>(_configuration.GetSection("IpRateLimiting"))
                .AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>()
                .AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>()
                .AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>()
                .AddHttpContextAccessor();

            return services;
        }
    }
}
