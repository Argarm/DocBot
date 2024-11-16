using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocBot.Startups;

public static class ActionsStartup {
    public static IServiceCollection ConfigureActions(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<CreateChatCommandHandler>();
        return services;
    }
}