using Microsoft.Extensions.DependencyInjection;
using UserManagement.AntiCorruption.User;
using UserManagement.Infrastructure.MsSql.User;

namespace UserManagement.Infrastructure.MsSql
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMsSql(this IServiceCollection services)
        {
            services.AddScoped<IUserFromDatabaseRepository, UserFromDatabaseRepository>();
            return services;
        }
    }
}
