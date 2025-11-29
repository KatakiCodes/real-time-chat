using System;

namespace realtime_chat_api.DTOs.Responses;

public record UserResponse
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public UserResponse(int id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }
}
