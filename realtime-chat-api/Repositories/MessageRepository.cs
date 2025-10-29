using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class MessageRepository : IMessageRepository
{
    public Message Create(Message entity)
    {
        throw new NotImplementedException();
    }

    public Message GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Message> GetMessagesByChatId(int chatId)
    {
        throw new NotImplementedException();
    }

    public Message Update(Message entity)
    {
        throw new NotImplementedException();
    }
}
