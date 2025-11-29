using System;

namespace realtime_chat_api.Repositories.Interface;

public interface IBaseRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(int id);
    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity);
}
