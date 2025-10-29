using System;

namespace realtime_chat_api.Repositories.Interface;

public interface IBaseRepository<T> where T : class
{
    public T GetByIdAsync(int id);
    public T CreateAsync(T entity);
    public T UpdateAsync(T entity);
}
