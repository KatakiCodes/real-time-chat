using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class MessageRepository : IMessageRepository
{
    public Message CreateAsync(Message entity)
    {
        throw new NotImplementedException();
    }

    public Message GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Message> GetMessagesByChatIdAsync(int chatId)
    {
        throw new NotImplementedException();
    }

    public Message UpdateAsync(Message entity)
    {
        throw new NotImplementedException();
    }
}
