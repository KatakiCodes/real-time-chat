namespace realtime_chat_api.DTOs.Responses;

public record class ChatResponse
{
    public int Id { get; init; }
    public int AdminId { get; init; }
    public string Name { get; init; }
    public string Code { get; init; }

    public ChatResponse(int id, int adminId, string name, string code)
    {
        Id = id;
        AdminId = adminId;
        Name = name;
        Code = code;
    }

}
