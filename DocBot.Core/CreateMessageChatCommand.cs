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

    public CreateMessageChatCommandHandler(ChatRepository chatRepository) {
        this.chatRepository = chatRepository;
    }
    public async Task<MessageResponse> Handle(CreateMessageChatCommand request, CancellationToken cancellationToken) {
        var chat = chatRepository.Get(Guid.Parse(request.chatId));
        chat.AddMessage(request.message, Role.User);
        chatRepository.Update(chat);
        return new MessageResponse { Message = "Mensaje de respuesta"};
    }
}