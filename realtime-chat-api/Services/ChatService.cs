using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class ChatService : IChatService
{
    public Chat CreateAsync(Chat chat)
    {
        throw new NotImplementedException();
    }

    public Chat GetByIdAsync(int chatId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Chat> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Chat UpdateChatNameAsync(Chat chat)
    {
        throw new NotImplementedException();
    }
}
