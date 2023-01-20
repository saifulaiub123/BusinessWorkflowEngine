using Microsoft.Extensions.DependencyInjection;
using BWE.Domain.IRepository;
using BWE.Infrastructure.Repository;
using BWE.Domain.DBModel;
using BWE.Domain.Model;

namespace BWE.Infrastructure.Dependency
{
    public static class RepositoryResolutionConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(Domain.IRepository.IRepository<BaseModel<T>), typeof(Repository.Repository<BaseModel<T>>));
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Server, int>, Repository<Server,int>>();
            services.AddScoped<IRepository<Permission, int>, Repository<Permission,int>>();
            return services;
        }
    }
}
