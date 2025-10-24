using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateChatNameDto
{
    [Required]
    public int id { get; init; }
    public string Name { get; init; } = string.Empty;
}
