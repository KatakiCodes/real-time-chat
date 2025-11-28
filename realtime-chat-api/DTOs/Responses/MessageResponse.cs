using realtime_chat_api.Enums;

namespace realtime_chat_api.DTOs.Responses;

public record MessageResponse
{
    public MessageResponse(int id, string content, User_ChatResponse user_Chat, DateTime date, EMessageState state)
    {
        Id = id;
        Content = content;
        User_Chat = user_Chat;
        Date = date;
        State = state.ToString();
    }

    public int Id { get; init; }
    public string Content { get; init; } = string.Empty;
    public User_ChatResponse User_Chat { get; set; }
    public DateTime Date { get; init; }
    public string State { get; init; }
}
