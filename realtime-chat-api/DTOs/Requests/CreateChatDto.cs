using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class CreateChatDto
{
    [Required]
    public string Name { get; init; } = string.Empty;
    [MinLength(6)]
    public string Code { get; init; } = string.Empty;
}
