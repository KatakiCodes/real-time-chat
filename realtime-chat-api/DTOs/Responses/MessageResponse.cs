using realtime_chat_api.Enums;

namespace realtime_chat_api.DTOs.Responses;

public record MessageResponse
{
    public MessageResponse(int id, string content, int userId, int chatId, DateTime date, EMessageState state)
    {
        Id = id;
        Content = content;
        UserId = userId;
        ChatId = chatId;
        Date = date;
        State = state.ToString();
    }

    public int Id { get; init; }
    public string Content { get; init; } = string.Empty;
    public int UserId { get; init; }
    public int ChatId { get; init; }
    public DateTime Date { get; init; }
    public string State { get; init; }
}
