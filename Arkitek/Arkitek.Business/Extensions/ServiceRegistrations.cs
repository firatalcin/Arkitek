using Arkitek.Business.Services.AboutServices;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitek.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService>();

            return services;
        }
    }
}
