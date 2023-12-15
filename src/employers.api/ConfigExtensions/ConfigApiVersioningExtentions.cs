using System.Diagnostics.CodeAnalysis;
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace employers.api.ConfigExtensions
{
    [ExcludeFromCodeCoverage]
    public static class ConfigApiVersioningExtentions
    {
        public static void GetApiVersioningExtentions(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            }).AddApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
