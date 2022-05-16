using System.Text;
using employers.api.ConfigExtensions;
using employers.api.Middlewares.Erros;
using employers.application.Mapper;
using employers.infrastructure.Ioc;
using employers.infrastructure.SwaggerExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Prometheus;

namespace employers.api
{
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
