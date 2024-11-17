namespace DocBot.Core;

public class ChatResponse {
    public string Guid { get; set; }
    public IList<MessageResponse> Message { get; set; }
}