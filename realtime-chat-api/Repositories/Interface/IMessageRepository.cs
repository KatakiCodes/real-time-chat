using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Repositories.Interface;

public interface IMessageRepository : IBaseRepository<Message>
{
    public IEnumerable<Message> GetMessagesByChatId(int chatId);
}
