using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class MessageService : IMessageService
{
    public Message CreateAsync(Message dto)
    {
        throw new NotImplementedException();
    }

    public Message EditMessageContentAsync(Message dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Message> GetByChatIdAsync(int chatId)
    {
        throw new NotImplementedException();
    }
}
