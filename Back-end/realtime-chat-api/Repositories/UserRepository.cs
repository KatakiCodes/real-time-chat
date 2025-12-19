using System;
using Microsoft.EntityFrameworkCore;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? findUser = await _context.Users.FindAsync(id);
        return findUser;
    }

    public async Task<User?> GetUserByEmailAsync(string email)=> await _context.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();

    public async Task<User> UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
