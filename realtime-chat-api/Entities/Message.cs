using System;
using realtime_chat_api.DomainExceptions;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Entities;

public class Message : Entity
{
    public User User { get; private set; }
    public Chat Chat { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public EMessageState State { get; private set; }

    public Message()
    { }
    public Message(User user, Chat chat, string content)
    {
        DomainException.When(user is null, "User cannot be empty");
        DomainException.When(chat is null, "Chat cannot be empty");
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        User = user!;
        Chat = chat!;
        Content = content;
        Date = DateTime.UtcNow;
        State = EMessageState.Sent;
    }
    public Message(Guid id, User user, Chat chat, string content) : base(id)
    {
        DomainException.When(user is null, "User cannot be empty");
        DomainException.When(chat is null, "Chat cannot be empty");
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        User = user!;
        Chat = chat!;
        Content = content;
        Date = DateTime.UtcNow;
        State = EMessageState.Sent;
    }
    public void UpdateContent(string content)
    {
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        this.Content = content;
        this.State = EMessageState.Edited;
    }
}
