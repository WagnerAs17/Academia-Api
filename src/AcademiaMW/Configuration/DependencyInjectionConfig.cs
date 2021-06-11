using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service;
using AcademiaMW.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AcademiaMW.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterInjection(this IServiceCollection services)
        {
            services.AddScoped<AcademiaContext>();

            //Business
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<INotificador, Notificador>();

            //Infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
