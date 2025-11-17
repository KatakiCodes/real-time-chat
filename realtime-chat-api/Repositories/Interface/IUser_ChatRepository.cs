using realtime_chat_api.Entities;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Repositories.Interface
{
    public interface IUser_ChatRepository
    {
        //To use when we need to filter all chat of a user
        public Task<IEnumerable<User_Chat>> GetByUserIdAsync(int userId);
        //To use when we need to filter all user of a chat
        public Task<IEnumerable<User_Chat>> GetByChatIdAsync(int chatId);
        public Task<User_Chat?> GetByIdAsync(int user_ChatId);
        public Task<User_Chat> CreateAsync(User_Chat user_Chat);
        public Task<User_Chat> UpdateAsync(User_Chat user_Chat);
        public Task Delete(User_Chat user_Chat);
    }
}