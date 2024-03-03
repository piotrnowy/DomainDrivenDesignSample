using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Application.Handlers
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
            return services;
        }
    }
}
