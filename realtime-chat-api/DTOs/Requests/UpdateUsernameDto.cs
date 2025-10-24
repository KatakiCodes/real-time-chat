using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateUsernameDto
{
    [MinLength(3)]
    [MaxLength(30)]
    public string Username { get; init; } = string.Empty;
}
