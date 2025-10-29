using System;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Repositories.Interface;

public interface IChatRepository : IBaseRepository<Chat>
{
    public Task<IEnumerable<Chat>> GetChatsByUserIdAsync(int userId);
}
