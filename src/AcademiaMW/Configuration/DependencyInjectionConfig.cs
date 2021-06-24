using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Extensions;
using AcademiaMW.Infra.Data;
using AcademiaMW.Infra.Security;
using AcademiaMW.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AcademiaMW.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterInjection(this IServiceCollection services)
        {
            services.AddScoped<AcademiaContext>();

            //Business
            services.AddScoped<INotificador, Notificador>();
            services.RegistrarInterfaces(typeof(IService), AssemblyNamespace.Service);

            //API
            services.AddScoped<AuthService>();

            //Infra
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IBCryptPasswordHasher, BcryptPasswordHasher>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }

        private static void RegistrarInterfaces(this IServiceCollection services, Type typeBase, string assemblyNamespace)
        {
            var types = typeBase
                .Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                    type.Namespace.Contains(assemblyNamespace) &&
                    type.Name.EndsWith(assemblyNamespace) &&
                    !type.IsGenericType &&
                    type.IsClass &&
                    type.GetInterfaces().Any());

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces()?
                    .FirstOrDefault(i => i.Name == $"I{type.Name}");

                if (interfaceType == null)
                    continue;

                services.AddScoped(interfaceType, type);
            }
                    
        }
    }
}
