namespace DocBot.Core;

public class ChatRepository {
    private IList<Chat> chats { get; } = new List<Chat>();
    public void Update(Chat chat) {
        chats.Add(chat);
    }

    public Chat Get(Guid chatId) {
        chats.FirstOrDefault(chat => chat.Guid.Equals(chatId));
        return new Chat();
    }
}