using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class CreateMessageRequest
{
    private int UserId { get; set; }
    [Required]
    public int ChatId { get; init; }
    [Required]
    public string Content { get; init; } = string.Empty;

    public void SetUserId(int id) => UserId = id;
    public int GetUserId() => UserId;
}
