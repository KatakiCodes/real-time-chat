using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class CreateMessageDto
{
    [Required]
    public string Content { get; init; } = string.Empty;
}
