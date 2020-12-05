using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace employers.infrastructure.SwaggerExtensions
{
    public static class SwaggerConfigExtensions
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CRUD API - v1",
                        Version = "v1",
                        Description = "Exemplo simples de um CRUD",
                        Contact = new OpenApiContact
                        {
                            Name = "Renato Groffe",
                            Url = new Uri("https://github.com/Carlinhao")
                        }
                    });

                //string caminhoAplicacao =
                //    PlatformServices.Default.Application.ApplicationBasePath;
                //string nomeAplicacao =
                //    PlatformServices.Default.Application.ApplicationName;
                //string caminhoXmlDoc =
                //    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD API - v1");
            });
        }

    }
}
