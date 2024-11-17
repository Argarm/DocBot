using Azure.AI.OpenAI;
using MediatR;

namespace DocBot.Core;

public class CreateMessageChatCommand : IRequest<MessageResponse> {
    public readonly string chatId;
    public readonly string message;

    public CreateMessageChatCommand(string chatId, string message) {
        this.chatId = chatId;
        this.message = message;
    }
}

public class CreateMessageChatCommandHandler : IRequestHandler<CreateMessageChatCommand, MessageResponse> {
    private readonly ChatRepository chatRepository;
    private readonly OpenAIClient client;
    private readonly DeploymentParameters deploymentParameters;

    public CreateMessageChatCommandHandler(ChatRepository chatRepository, OpenAIClient client, DeploymentParameters deploymentParameters) {
        this.chatRepository = chatRepository;
        this.client = client;
        this.deploymentParameters = deploymentParameters;
    }
    public async Task<MessageResponse> Handle(CreateMessageChatCommand request, CancellationToken cancellationToken) {
        var chat = chatRepository.Get(Guid.Parse(request.chatId));
        chat.AddMessage(request.message, Role.User);
        var botMessage = ReponseTo(request.message);
        chat.AddMessage(botMessage, Role.Assistant);
        chatRepository.Update(chat);
        return new MessageResponse { Message = botMessage, Role = Role.Assistant };
    }

    private string ReponseTo(string requestMessage) {
        var chatCompletionsOptions = new ChatCompletionsOptions() {
            Messages = {
                new ChatRequestUserMessage(requestMessage)
            },
            MaxTokens = deploymentParameters.MaxTokens,
            Temperature = deploymentParameters.Temperature,
            DeploymentName = deploymentParameters.DeploymentName
        };
        ChatCompletions response = client.GetChatCompletions(chatCompletionsOptions);
        return response.Choices[0].Message.Content;
    }
}

public class DeploymentParameters {
    public int MaxTokens { get; set; }
    public float Temperature { get; set; }
    public string DeploymentName { get; set; }
}