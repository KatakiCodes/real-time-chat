using System;
using Microsoft.EntityFrameworkCore;
using realtime_chat_api.Data;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;

namespace realtime_chat_api.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _Context; 
    public MessageRepository(AppDbContext context)
    {
        _Context = context;
    }
    public async Task<Message> CreateAsync(Message entity)
    {
        await _Context.Messages.AddAsync(entity);
        await _Context.SaveChangesAsync();
        return entity;
    }

    public async Task<Message?> GetByIdAsync(int id) => await _Context.Messages.FindAsync(id);

    public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(int chatId)=> await _Context.Messages.AsNoTracking().Where(m => m.ChatId == chatId).ToListAsync();

    public async Task<Message> UpdateAsync(Message entity)
    {
        _Context.Messages.Update(entity);
        await _Context.SaveChangesAsync();
        return entity;
    }
}
