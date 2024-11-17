using MediatR;

namespace DocBot.Core;

public record GetChatQuery(string ChatId) : IRequest<ChatResponse>;


public class GetChatQueryHandler : IRequestHandler<GetChatQuery,ChatResponse> {
    private readonly ChatRepository repository;

    public GetChatQueryHandler(ChatRepository repository) {
        this.repository = repository;
    }

    public async Task<ChatResponse> Handle(GetChatQuery request, CancellationToken cancellationToken) {
        var chat = repository.Get(Guid.Parse(request.ChatId));
        return chat.ToChatResponse();
    }
}