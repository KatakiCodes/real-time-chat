using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateMessageRequest
{
    [Required]
    public int Id { get; init; }
    [Required]
    public string Content { get; init; } = string.Empty;
}
