using AcademiaMW.Infra.Data;
using AcademiaMW.Infra.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace AcademiaMW.Configuration
{
    public static class ApiConfig
    {
        private static readonly string transLogPolicy = "TranslogPolicy";
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.ApiVersioning();
            
            services.AddDbContext<AcademiaContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var emailOptions = configuration.GetSection("EmailOptions");
            services.Configure<EmailOptions>(emailOptions);

            services.AddCors(options =>
            {
                options.AddPolicy(transLogPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                        .WithMethods("GET", "POST", "PUT", "DELETE");
                });
            });
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(transLogPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ApiVersioning(this IServiceCollection services )
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
