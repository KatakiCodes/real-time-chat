namespace realtime_chat_api.DTOs.Responses;

public record ChatResponse
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Name { get; init; }
    public string Code { get; init; }

    public ChatResponse(int id, int userId, string name, string code)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Code = code;
    }

}
