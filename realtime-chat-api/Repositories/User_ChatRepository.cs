using Microsoft.EntityFrameworkCore;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
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
            return await this.GetByIdAsync(user_Chat.Id);
        }

        public async Task Delete(User_Chat user_chat)
        {
            _Context.User_Chats.Remove(user_chat);
            await _Context.SaveChangesAsync();
        }

        public async Task<User_Chat?> GetByChatIdAndUserIdAsync(int userId, int chatId)
        {
            return await _Context.User_Chats.Where(u_c => u_c.UserId == userId && u_c.ChatId == chatId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User_Chat>> GetByChatIdAsync(int chatId) => await _Context.User_Chats.AsNoTracking().Where(c => c.ChatId == chatId).ToListAsync();

        public async Task<User_Chat?> GetByIdAsync(int user_ChatId) => await _Context.User_Chats.Where(u_c=>u_c.Id == user_ChatId).FirstOrDefaultAsync();

        public async Task<IEnumerable<User_Chat>> GetByUserIdAsync(int userId) => await _Context.User_Chats.AsNoTracking().Where(c => c.UserId == userId).ToListAsync();

        public async Task<User_Chat> UpdateAsync(User_Chat user_chat)
        {
            _Context.User_Chats.Update(user_chat);
            await _Context.SaveChangesAsync();
            return await this.GetByIdAsync(user_chat.Id);
        }
    }
}