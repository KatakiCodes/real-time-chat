using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class CreateChatRequest
{
    private int AdminId { get; set; }
    [Required]
    public string Name { get; init; } = string.Empty;
    [MinLength(6)]
    public string Code { get; init; } = string.Empty;
    public void SetUserId(int id)=>AdminId = id;
    public int GetUserId()=>AdminId;
}
