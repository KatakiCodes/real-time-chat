using System;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class UserRepository : IBaseRepository<User>
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public User GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public User UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
