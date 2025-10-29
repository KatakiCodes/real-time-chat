using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IMessageService
{
    public IEnumerable<Message> GetByChatIdAsync(int chatId);
    public Message CreateAsync(Message dto);
    public Message EditMessageContentAsync(Message dto);
}
