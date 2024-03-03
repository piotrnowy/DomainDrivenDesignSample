using Microsoft.Extensions.DependencyInjection;
using UserManagement.AntiCorruption.User;
using UserManagement.Application.Handlers;

namespace UserManagement.AntiCorruption
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAntiCorruption(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
