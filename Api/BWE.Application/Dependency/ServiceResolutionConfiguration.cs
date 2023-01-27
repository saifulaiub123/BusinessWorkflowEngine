using BWE.Application.IService;
using BWE.Application.Service;
using BWE.Domain.IEntity;
using Microsoft.Extensions.DependencyInjection;

namespace BWE.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<IScriptService, ScriptService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IScriptUserPermissionService, ScriptUserPermissionService>();

            return services;
        }
    }
}
