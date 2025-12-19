using System;
using realtime_chat_api.DomainExceptions;

namespace realtime_chat_api.Entities;

public class Chat : Entity
{
    public int UserId { get; private set; }
    public User User { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    private List<Message> Messages { get; set; }
    public Chat()
    { }
    public Chat(User user, string name, string code)
    {
        DomainException.When(user is null, "Admin cannot be empty");
        Name = name;
        User = user!;
        UserId = user!.Id;
        Code = code;
    }
    public Chat(int id, User user, string name, string code) : base(id)
    {
        DomainException.When(user is null, "Admin cannot be empty");
        Name = name;
        User = user!;
        UserId = user!.Id;
        Code = code;
    }
    public void UpdateChatName(string name)
    {
        DomainException.When(string.IsNullOrEmpty(name), "Chat name cannot be empty");
        this.Name = name;
    }
}
