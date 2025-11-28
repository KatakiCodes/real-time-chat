using System;
using realtime_chat_api.DomainExceptions;
using realtime_chat_api.Enums;

namespace realtime_chat_api.Entities;

public class Message : Entity
{
    public int User_ChatId { get; private set; }
    public User_Chat User_Chat { get; private set; }
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public EMessageState State { get; private set; }

    public Message()
    {
        Date = DateTime.UtcNow;
    }
    public Message(User_Chat user_chat, string content)
    {
        DomainException.When(user_chat is null, "User cannot be empty");
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        User_Chat = user_chat!;
        User_ChatId = user_chat!.Id;
        Content = content;
        Date = DateTime.UtcNow;
        State = EMessageState.Sent;
    }
    public Message(int id, User_Chat user_chat, string content) : base(id)
    {
        DomainException.When(user_chat is null, "User cannot be empty");
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        User_Chat = user_chat!;
        User_ChatId = user_chat!.Id;
        Content = content;
        Date = DateTime.Now;
        State = EMessageState.Sent;
    }
    public void UpdateContent(string content)
    {
        DomainException.When(string.IsNullOrEmpty(content), "Content cannot be empty");
        this.Content = content;
        this.State = EMessageState.Edited;
    }
    public void DeleteMessage() => this.State = EMessageState.Deleted;
}
