using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _Repository;
    public ChatService(IChatRepository repository)
    {
        _Repository = repository;
    }
    public async Task<Chat> CreateAsync(Chat chat)=> await _Repository.CreateAsync(chat);

    public async Task<Chat?> GetByIdAsync(int chatId)=> await _Repository.GetByIdAsync(chatId);

    public async Task<IEnumerable<Chat>> GetByUserIdAsync(int userId)=> await _Repository.GetChatsByUserIdAsync(userId);

    public async Task<Chat> UpdateChatNameAsync(Chat chat) => await _Repository.UpdateAsync(chat);
}
