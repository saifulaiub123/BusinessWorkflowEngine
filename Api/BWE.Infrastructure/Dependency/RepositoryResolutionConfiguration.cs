using Microsoft.Extensions.DependencyInjection;
using BWE.Domain.IRepository;
using BWE.Infrastructure.Repository;
using BWE.Domain.DBModel;

namespace BWE.Infrastructure.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            #region Services
            //services.AddScoped(typeof(Domain.IRepository.IRepository<typeof(Script),int>), typeof(Repository.Repository<typeof(Script),int>));
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Server, int>, Repository<Server,int>>();
            services.AddScoped<IRepository<Permission, int>, Repository<Permission,int>>();
            services.AddScoped<IRepository<Script, int>, Repository<Script,int>>();
            services.AddScoped<IRepository<ScriptHistory, int>, Repository<ScriptHistory, int>>();
            services.AddScoped<IRepository<ScriptUserPermission, int>, Repository<ScriptUserPermission, int>>();
            #endregion
            return services;
        }
    }
}
