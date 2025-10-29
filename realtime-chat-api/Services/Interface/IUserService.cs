using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IUserService
{
    public User GetByIdAsync(int userId);
    public User Create(User user);
    public User UpdateUserName(User user);
}
