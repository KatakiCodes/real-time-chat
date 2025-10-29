using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class ChatRepository : IChatRepository
{
    public Chat Create(Chat entity)
    {
        throw new NotImplementedException();
    }

    public Chat GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Chat> GetChatsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Chat Update(Chat entity)
    {
        throw new NotImplementedException();
    }
}
