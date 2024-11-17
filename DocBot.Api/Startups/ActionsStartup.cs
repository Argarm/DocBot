using DocBot.Core;

namespace DocBot.Startups;

public static class ActionsStartup {
    public static IServiceCollection ConfigureActions(this IServiceCollection services) {
        services.AddMediatR(meditorConfiguration =>
            meditorConfiguration.RegisterServicesFromAssemblies(typeof(ChatResponse).Assembly));
        services.AddScoped<ChatRepository>();
        services.AddScoped<CreateChatCommand>();
        services.AddScoped<CreateChatCommandHandler>();
        return services;
    }
}