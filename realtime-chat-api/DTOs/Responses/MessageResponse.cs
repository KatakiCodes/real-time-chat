namespace realtime_chat_api.DTOs.Responses;

public record class MessageResponse
{
    public MessageResponse(int id, string content, int userId, int chatId, DateTime date)
    {
        Id = id;
        Content = content;
        UserId = userId;
        ChatId = chatId;
        Date = date;
    }

    public int Id { get; init; }
    public string Content { get; init; } = string.Empty;
    public int UserId { get; init; }
    public int ChatId { get; init; }
    public DateTime Date { get; init; }
}
