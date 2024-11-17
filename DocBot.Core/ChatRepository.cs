namespace DocBot.Core;

public class ChatRepository {
    private IList<Chat> chats { get; } = new List<Chat>();
    public void Update(Chat chat) {
        var existingChat = chats.FirstOrDefault(c => c.Id.Equals(chat.Id));
        if (existingChat != null) {
            existingChat = chat;
        } else {
            chats.Add(chat);
        }
    }

    public Chat Get(Guid chatId) {
        return chats.Single(chat => chat.Id.Equals(chatId));
    }
}