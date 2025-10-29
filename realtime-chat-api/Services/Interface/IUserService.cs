using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IUserService
{
    public Task<User?> GetByIdAsync(int userId);
    public Task<User> CreateAsync(User user);
    public Task<User> UpdateUserNameAsync(User user);
}
