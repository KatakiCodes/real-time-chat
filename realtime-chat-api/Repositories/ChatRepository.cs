using System;
using Microsoft.EntityFrameworkCore;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _Context;
    public ChatRepository(AppDbContext context)
    {
        _Context = context;
    }
    public async Task<Chat> CreateAsync(Chat entity)
    {
        await _Context.Chats.AddAsync(entity);
        await _Context.SaveChangesAsync();
        return entity;
    }

    public async Task<Chat?> GetByIdAsync(int id)=> await _Context.Chats.FindAsync(id);

    public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(int userId)=> await _Context.Chats.AsNoTracking()
            .Where(c => c.AdminId == userId).ToListAsync();

    public async Task<Chat> UpdateAsync(Chat entity)
    {
        _Context.Chats.Update(entity);
        await _Context.SaveChangesAsync();
        return entity;
    }
}
