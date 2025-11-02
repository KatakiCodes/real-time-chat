using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateChatNameRequest
{
    [Required]
    public int Id { get; init; }
    [Required]
    public string Name { get; init; } = string.Empty;
}
