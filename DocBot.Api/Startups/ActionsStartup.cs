using System.Globalization;
using Azure;
using Azure.AI.OpenAI;
using DocBot.Core;

namespace DocBot.Startups;

public static class ActionsStartup {
    public static IServiceCollection ConfigureActions(this IServiceCollection services, IConfiguration configuration) {
        services.AddMediatR(meditorConfiguration =>
            meditorConfiguration.RegisterServicesFromAssemblies(typeof(ChatResponse).Assembly));
        services.AddSingleton<ChatRepository>();
        services.AddScoped<CreateChatCommand>();
        services.AddScoped<CreateChatCommandHandler>();
        services.AddScoped<OpenAIClient>(_ =>
            new OpenAIClient(
                new Uri(configuration["AzureOpenAI:Endpoint"]),
                new AzureKeyCredential(configuration["AzureOpenAI:Key"]))
        );
        services.AddSingleton<DeploymentParameters>(_ =>
            new DeploymentParameters {
                Temperature = float.Parse(configuration["AzureOpenAI:Temperature"],CultureInfo.InvariantCulture),
                DeploymentName = configuration["AzureOpenAI:DeploymentName"],
                MaxTokens = Int16.Parse(configuration["AzureOpenAI:MaxTokens"])
            }
         );
        return services;
    }
}