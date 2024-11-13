using System.Text.Json;
using System.Text.Json.Serialization;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocBot.Api;

public class Startup {
    private readonly IConfiguration configuration;
    private string ProductName = "DocBot";

    public Startup(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddMvcCore()
            .AddMvcOptions(options =>
                options.Filters.Add(new ProducesAttribute("application/json"))
            )
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services
            .ConfigureActions(configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }

        app
            .UseMiddleware<ExceptionMiddleware>()
            .UseOpenApi()
            .UseSwaggerUi()
            .UseRouting()
            .UseEndpoints(endpoints => {
                endpoints
                    .MapControllers();
            });
    }
}