using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateMessageDto
{
    [Required]
    public string Content { get; init; } = string.Empty;
}
