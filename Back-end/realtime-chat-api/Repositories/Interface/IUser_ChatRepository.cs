using realtime_chat_api.Entities;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Repositories.Interface
{
    public interface IUser_ChatRepository : IBaseRepository<User_Chat>
    {
        public Task<IEnumerable<User_Chat>> GetByUserIdAsync(int userId);
        public Task<IEnumerable<User_Chat>> GetByChatIdAsync(int chatId);
        public Task<User_Chat?> GetByChatIdAndUserIdAsync(int userId,int chatId);
        public Task Delete(User_Chat user_Chat);
    }
}