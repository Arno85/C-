using CqrsAndMediatR.Infrastructure.Abstractions;
using CqrsAndMediatR.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsAndMediatR.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICustomersRepository, CustomersRepository>();

            return services;
        }
    }
}
