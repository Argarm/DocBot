using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace DocBot.Startups;

public static class VersioningStartup {
    public static IServiceCollection ConfigureVersioning(this IServiceCollection services) {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc() 
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        return services;
    }
}