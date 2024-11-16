using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DocBot.Startups;

public static class SwaggerStartup {
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "DocBot Api", Version = "v1" });
        });
        return services;
    }
}