using Arkitek.DataAccess.Interceptors;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitek.DataAccess.Extensions
{
    public static class RepositoryRegistrations
    {
        public static IServiceCollection AddRepositoryExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                opt.AddInterceptors(new AuditDbContextInterceptor());
            });

            services.Scan(opt => opt
            .FromAssemblyOf<DataAccessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
