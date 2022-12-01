using Helpers.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Helpers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectHelpers(this IServiceCollection services, IConfiguration config)
        {
            services.AddMemoryCache();
            services.AddScoped<ICache, Cache.Cache>();
            return services;
        }
    }
}