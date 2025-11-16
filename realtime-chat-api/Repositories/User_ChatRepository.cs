using Microsoft.EntityFrameworkCore;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
using realtime_chat_api.Enums;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories
{
    public class User_ChatRepository : IUser_ChatRepository
    {
        private readonly AppDbContext _Context;

        public User_ChatRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<User_Chat> CreateAsync(User_Chat user_Chat)
        {
            await _Context.User_Chats.AddAsync(user_Chat);
            await _Context.SaveChangesAsync();
            return user_Chat;
        }

        public async Task Delete(User_Chat user_chat) => _Context.User_Chats.Remove(user_chat);

        public async Task<IEnumerable<User_Chat>> GetByChatIdAsync(int chatId) => await _Context.User_Chats.AsNoTracking().Where(c=>c.ChatId == chatId).ToListAsync();

        public async Task<User_Chat?> GetByIdAsync(int user_ChatId)=> await _Context.User_Chats.FindAsync(user_ChatId);

        public async Task<IEnumerable<User_Chat>> GetByUserIdAsync(int userId)=> await _Context.User_Chats.AsNoTracking().Where(c=>c.UserId == userId).ToListAsync();
    }
}