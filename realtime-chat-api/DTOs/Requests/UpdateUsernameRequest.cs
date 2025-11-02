using System.ComponentModel.DataAnnotations;

namespace realtime_chat_api.DTOs.Requests;

public record class UpdateUsernameRequest
{
    [MinLength(3)]
    [MaxLength(30)]
    public string Username { get; init; } = string.Empty;
    private int UserId { get; set; }
    public int GetUserId() => UserId;
    public void SetUserId(int id) => UserId = id;
}
