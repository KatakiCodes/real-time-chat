using System;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class MessageService : IMessageService
{
    private IMessageRepository _Repository;
    public MessageService(IMessageRepository repository)
    {
        _Repository = repository;
    }

    public async Task<Message> CreateAsync(Message message)=> await _Repository.CreateAsync(message);

    public Task<Message> EditMessageContentAsync(Message message)=> _Repository.UpdateAsync(message);

    public Task<IEnumerable<Message>> GetByChatIdAsync(int chatId)=> _Repository.GetMessagesByChatIdAsync(chatId);
}
