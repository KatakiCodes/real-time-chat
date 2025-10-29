using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IMessageService
{
    public Task<IEnumerable<Message>> GetByChatIdAsync(int chatId);
    public Task<Message> CreateAsync(Message message);
    public Task<Message> EditMessageContentAsync(Message message);
}
