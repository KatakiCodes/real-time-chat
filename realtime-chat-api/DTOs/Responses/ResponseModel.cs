namespace realtime_chat_api.DTOs.Responses;

public record class ResponseModel<T> where T : class
{
    public bool success { get; init; }
    public T? data { get; init; }
}
