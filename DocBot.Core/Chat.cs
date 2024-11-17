namespace DocBot.Core;

public class Chat {
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Message> Messages { get; set; } = new();

    public void AddMessage(string text, Role role) {
        Messages.Add(new Message {
            Text = text,
            Role = Role.User
        });
    }
}

