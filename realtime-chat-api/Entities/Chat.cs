using System;
using realtime_chat_api.DomainExceptions;

namespace realtime_chat_api.Entities;

public class Chat : Entity
{
    public User Admin { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Chat()
    { }
    public Chat(User admin, string name, string code)
    {
        DomainException.When(admin is null, "Admin cannot be empty");
        Name = name;
        Admin = admin!;
        Code = code;
    }
    public Chat(int id, User admin, string name, string code) : base(id)
    {
        DomainException.When(admin is null, "Admin cannot be empty");
        Name = name;
        Admin = admin!;
        Code = code;
    }
    public void UpdateChatName(string name)
    {
        DomainException.When(string.IsNullOrEmpty(name), "Chat name cannot be empty");
        this.Name = name;
    }
}
