using BWE.Api.Authentication;

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
