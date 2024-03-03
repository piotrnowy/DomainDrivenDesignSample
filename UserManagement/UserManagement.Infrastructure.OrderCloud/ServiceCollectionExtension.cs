using Microsoft.Extensions.DependencyInjection;
using UserManagement.AntiCorruption.User;

namespace UserManagement.Infrastructure.OrderCloud
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOrderCloud(this IServiceCollection services)
        {
            services.AddScoped<IUserFromOrderCloud, UserFromOrderCloudRepository>();
            return services;
        }
    }
}
