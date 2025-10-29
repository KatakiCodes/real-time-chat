using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IChatService
{
    public Chat GetByIdAsync(int chatId);
    public IEnumerable<Chat> GetByUserIdAsync(int userId);
    public Chat CreateAsync(Chat chat);
    public Chat UpdateChatNameAsync(Chat chat);
}
