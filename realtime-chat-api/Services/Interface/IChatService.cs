using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IChatService
{
    public Task<Chat?> GetByIdAsync(int chatId);
    public Task<IEnumerable<Chat>> GetByUserIdAsync(int userId);
    public Task<Chat> CreateAsync(Chat chat);
    public Task<Chat> UpdateChatNameAsync(Chat chat);
}
