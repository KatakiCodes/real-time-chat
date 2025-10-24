using System;
using realtime_chat_api.DomainExceptions;
namespace realtime_chat_api.Entities;

public class User : Entity
{
    public string email { get; private set; }
    public string Username { get; private set; }

    public User()
    { }

    public User(string email, string username)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");

        this.email = email;
        this.Username = username;
    }
    public User(int id, string email, string username) : base(id)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        
        this.email = email;
        this.Username = username;
    }
    public void UpdateUserName(string username)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Username cannot be empty");
        this.Username = username;
    }
}
