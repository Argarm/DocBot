using System.Runtime.CompilerServices;
using MediatR;

namespace DocBot.Core;

public class CreateChatCommand : IRequest<ChatResponse> {
    public string chatName { get; set; }
}

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ChatResponse> {
    private readonly ChatRepository chatRepository;

    public CreateChatCommandHandler(ChatRepository chatRepository) {
        this.chatRepository = chatRepository;
    }
    public async Task<ChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken) {
        return new ChatResponse{Guid = Guid.NewGuid().ToString()};
    }
}

public class ChatRepository {
    public IList<Chat> Chats { get; } = new List<Chat>();
    public void Update() {
        
    }

    public Chat Get(Guid chatId) {
        return new Chat();
    }
}

public class Chat {
    public Guid Guid { get; set; }
    public string Name { get; set; }
}