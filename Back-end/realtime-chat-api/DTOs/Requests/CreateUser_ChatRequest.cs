
namespace realtime_chat_api.DTOs.Requests
{
    public record CreateUser_ChatRequest
    {
        public CreateUser_ChatRequest(int userId, int chatId, bool isAdmin)
        {
            UserId = userId;
            ChatId = chatId;
            IsAdmin = isAdmin;
        }

        public int UserId { get; init; }
        public int ChatId { get; init; }
        public bool IsAdmin { get; init; }
    }
}