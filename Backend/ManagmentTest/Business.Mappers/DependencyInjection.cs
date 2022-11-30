using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Mappers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddViewModelMaping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}