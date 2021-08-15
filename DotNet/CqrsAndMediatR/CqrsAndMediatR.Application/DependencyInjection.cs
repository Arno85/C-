using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsAndMediatR.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
