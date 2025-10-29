using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class ChatRepository : IChatRepository
{
    public Chat CreateAsync(Chat entity)
    {
        throw new NotImplementedException();
    }

    public Chat GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Chat> GetChatsByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Chat UpdateAsync(Chat entity)
    {
        throw new NotImplementedException();
    }
}
