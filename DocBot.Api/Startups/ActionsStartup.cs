using System.Reflection;
using DocBot.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocBot.Startups;

public static class ActionsStartup {
    public static IServiceCollection ConfigureActions(this IServiceCollection services) {
        services.AddMediatR(meditorConfiguration =>
            meditorConfiguration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<CreateChatCommand>();
        services.AddScoped<CreateChatCommandHandler>();
        return services;
    }
}