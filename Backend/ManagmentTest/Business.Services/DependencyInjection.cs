using Business.Services.IRepository;
using Business.Services.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientAddressRepository, ClientAddressRepository>();
            services.AddTransient<IClientNumberRepository, ClientNumberRepository>();

            return services;

        }
    }
}