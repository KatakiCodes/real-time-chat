using System;

namespace realtime_chat_api.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public Entity(int id)
    {
        Id = id;
    }
    public Entity()
    {}
}
