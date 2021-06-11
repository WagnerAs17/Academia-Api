using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace AcademiaMW.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggnerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.OperationFilter<SwaggerDefaultValues>();
                

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var descriptor in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{descriptor.GroupName}/swagger.json", $"Academia - {descriptor.GroupName}");
                }
            });
        }
    }

    public class ConfigurationSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigurationSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var descriptor in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descriptor.GroupName, CreateInfoApiVersion(descriptor));
            }
        }

        static OpenApiInfo CreateInfoApiVersion(ApiVersionDescription description)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Gerenciamento de Academia",
                Version = description.ApiVersion.ToString(),
                Description = "Software para gerenciamento de academias.",
                Contact = new OpenApiContact { Name = "Wagner Santos", Email = "almeidawagner405@gmail.com" },
                License = new OpenApiLicense { Name = "MW Site", Url = new Uri("https://github.com/WasAlmeida") }
            };

            if (description.IsDeprecated)
                apiInfo.Description += "Está versão da api está obsoleta";

            return apiInfo;
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            operation.Deprecated = apiDescription.IsDeprecated();

            if (operation.Parameters == null)
                return;

            foreach (var parameter in operation.Parameters.OfType<OpenApiParameter>())
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                if (parameter.Description == null)
                    parameter.Description = description.ModelMetadata?.Description;

                parameter.Required |= description.IsRequired;
            }
        }
    }
}
