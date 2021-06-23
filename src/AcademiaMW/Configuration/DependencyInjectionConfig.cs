using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Infra.Data;
using AcademiaMW.Infra.Security;
using AcademiaMW.Services;
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
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            //API
            services.AddScoped<AuthService>();

            //Infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IBCryptPasswordHasher, BcryptPasswordHasher>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
