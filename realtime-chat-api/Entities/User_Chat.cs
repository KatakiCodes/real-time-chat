using realtime_chat_api.DomainExceptions;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Entities
{
    public class User_Chat : Entity
    {
        public User_Chat(User user, Chat chat, EUserChatActivityState activityState)
        {
            DomainException.When(user is null, "Invalid user");
            DomainException.When(chat is null, "Invalid chat");
            User = user;
            Chat = chat;
            UserId = user.Id;
            ChatId = chat.Id;
            ActivityState = activityState;
        }

        public User User { get; private set; }
        public Chat Chat { get; private set; }
        public int UserId { get; private set; }
        public int ChatId { get; private set; }
        public EUserChatActivityState ActivityState { get; private set; }
    }
}