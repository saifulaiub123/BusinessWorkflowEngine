using BWE.Application.Helper;
using BWE.Application.IHelper;
using BWE.Application.IService;
using BWE.Application.Service;
using BWE.Domain.IEntity;
using BWE.Domain.UnitOfWork;
using BWE.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BWE.Application.Dependency
{
    public static class ServiceResolutionConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<IScriptService, ScriptService>();
            services.AddScoped<IScriptHistoryService, ScriptHistoryService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IScriptUserPermissionService, ScriptUserPermissionService>();



            services.AddScoped<IPowerShellHelper, PowerShellHelper>();

            return services;
        }
    }
}
