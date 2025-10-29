using System;

namespace realtime_chat_api.Repositories.Interface;

public interface IBaseRepository<T> where T : class
{
    public T GetById(int id);
    public T Create(T entity);
    public T Update(T entity);
}
