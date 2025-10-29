using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class UserRepository : IBaseRepository<User>
{
    public User Create(User entity)
    {
        throw new NotImplementedException();
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }
}
