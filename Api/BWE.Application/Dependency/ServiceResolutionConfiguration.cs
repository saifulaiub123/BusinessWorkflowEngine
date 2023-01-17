using BWE.Application.IService;
using BWE.Application.Service;
using BWE.Domain.IEntity;
using Microsoft.Extensions.DependencyInjection;
using BWE.Domain.IRepository;
using BWE.Infrastructure.Repository;

namespace BWE.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
