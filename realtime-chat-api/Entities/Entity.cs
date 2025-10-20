using System;

namespace realtime_chat_api.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public Entity(Guid id)
    {
        Id = id;
    }
    public Entity()
    {
        Id = Guid.NewGuid();
    }
}
