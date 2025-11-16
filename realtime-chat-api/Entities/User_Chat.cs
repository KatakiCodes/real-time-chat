using realtime_chat_api.DomainExceptions;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Entities
{
    public class User_Chat : Entity
    {
        public User_Chat()
        {
            DateCreate = DateTime.UtcNow;
        }
        public User_Chat(int userId, int chatId, EUserChatActivityState activityState, bool isAdmin)
        {
            UserId = userId;
            ChatId = chatId;
            ActivityState = activityState;
            IsAdmin = isAdmin;
            DateCreate = DateTime.UtcNow;
        }

        public User? User { get; private set; }
        public Chat? Chat { get; private set; }
        public int UserId { get; private set; }
        public int ChatId { get; private set; }
        public EUserChatActivityState ActivityState { get; private set; }
        public bool IsAdmin { get; private set; }
        public DateTime DateCreate { get; private set; }
    }
}