using employers.infrastructure.SwaggerExtensions;
using employers.api.ConfigExtensions;
using employers.application.Mapper;
using employers.infrastructure.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Prometheus;
using System.Diagnostics.CodeAnalysis;
using employers.api.Middlewares.Error;

namespace employers.api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.GetServicesExtensions(Configuration);
            services.AddControllers();
            services.IocConfiguration(Configuration);
            IOC.Rister();
            services.GetApiVersioningExtentions();
            services.AddAutoMapper(typeof(MappingProfile));
            services.SwaggerServices();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<GlobalErrorHandler>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseHttpMetrics();
            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
            app.SwaggerConfigure();

            app.UseMiddleware<GlobalErrorHandler>();
        }
    }
}
