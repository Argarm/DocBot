namespace DocBot.Core;

public static class ChatExtensions {
    public static ChatResponse ToChatResponse(this Chat chat) {
        return new ChatResponse {Guid = chat.Id.ToString()};
    }
}