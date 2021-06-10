using AcademiaMW.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaMW.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterInjection(this IServiceCollection services)
        {
            services.AddScoped<AcademiaContext>();
        }
    }
}
