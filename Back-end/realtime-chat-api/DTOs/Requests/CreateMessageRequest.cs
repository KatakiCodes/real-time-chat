using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record CreateMessageRequest
{
    [Required]
    public int User_ChatId { get; init; }
    [Required]
    public string Content { get; init; } = string.Empty;
}
