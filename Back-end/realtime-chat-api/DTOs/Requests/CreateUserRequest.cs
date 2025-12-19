using System;
using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record CreateUserRequest
{
    [MinLength(3)]
    [MaxLength(30)]
    public string Username { get; init; } = string.Empty;
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
    [MinLength(6)]
    [MaxLength(50)]
    public string Password { get; init; } = string.Empty;
}
