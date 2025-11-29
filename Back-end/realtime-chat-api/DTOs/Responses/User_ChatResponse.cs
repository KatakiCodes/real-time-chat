namespace realtime_chat_api.DTOs.Responses
{
    public record User_ChatResponse
    {
        public User_ChatResponse()
        {}
        
        public User_ChatResponse(int userId, int chatId, string activityState, bool isAdmin, DateTime dateCreate)
        {
            UserId = userId;
            ChatId = chatId;
            ActivityState = activityState;
            IsAdmin = isAdmin;
            DateCreate = dateCreate;
        }

        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string ActivityState { get; init; }
        public bool IsAdmin { get; init; }
        public DateTime DateCreate { get; init; }
    }
}