using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class UserService : IUserService
{
    private IUserRepository _Repository;
    public UserService(IUserRepository repository)
    {
        _Repository = repository;
    }

    public async Task<User> CreateAsync(User user)=> await _Repository.CreateAsync(user);

    public async Task<User?> GetByIdAsync(int userId) => await _Repository.GetByIdAsync(userId);

    public async Task<User> UpdateUserNameAsync(User user)=> await _Repository.UpdateAsync(user);
}
