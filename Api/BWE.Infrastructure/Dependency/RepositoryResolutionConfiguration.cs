using Microsoft.Extensions.DependencyInjection;
using BWE.Domain.IRepository;
using BWE.Infrastructure.Repository;

namespace BWE.Infrastructure.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
