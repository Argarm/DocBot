using MediatR;

namespace DocBot.Core;

public class CreateChatCommand : IRequest<ChatResponse>;
public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ChatResponse> {
    private readonly ChatRepository chatRepository;

    public CreateChatCommandHandler(ChatRepository chatRepository) {
        this.chatRepository = chatRepository;
    }
    public async Task<ChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken) {
        var chat = new Chat();
        chatRepository.Update(chat);
        return new ChatResponse{Guid = chat.Guid.ToString()};
    }
}