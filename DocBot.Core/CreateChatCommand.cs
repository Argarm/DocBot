using System.Runtime.CompilerServices;
using MediatR;

namespace DocBot.Core;

public class CreateChatCommand : IRequest<ChatResponse> {
    public string chatName { get; set; }
}

public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ChatResponse> {
    public async Task<ChatResponse> Handle(CreateChatCommand request, CancellationToken cancellationToken) {
        return new ChatResponse{Guid = Guid.NewGuid().ToString()};
    }
}