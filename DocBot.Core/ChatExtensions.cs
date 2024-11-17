namespace DocBot.Core;

public static class ChatExtensions {
    public static ChatResponse ToChatResponse(this Chat chat) {
        return new ChatResponse {
            Guid = chat.Id.ToString(),
            Message = chat.Messages.Select(message => message.ToMessageResponse()).ToList(),
        };
    }
}

public static class MessageExtensions {
    public static MessageResponse ToMessageResponse(this Message message) {
        return new MessageResponse {
            Message = message.Text,
            Role = message.Role,
        };
    }
}