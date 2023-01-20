using BWE.Api.Authentication;
using BWE.Application.IService;
using BWE.Application.Service;
using BWE.Domain.DBModel;
using BWE.Domain.IRepository;

namespace BWE.Api.Dependency
{
    public static class ApplicationResolutionConfiguration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenHelper>();
            return services;
        }
    }
}
