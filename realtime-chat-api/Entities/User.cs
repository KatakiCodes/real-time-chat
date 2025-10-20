using System;
using realtime_chat_api.DomainExceptions;
namespace realtime_chat_api.Entities;

public class User : Entity
{
    public string email { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public User()
    { }

    public User(string email, string username, string passwordHash)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        DomainException.When(string.IsNullOrEmpty(passwordHash), "PasswordHash cannot be empty");

        this.email = email;
        this.Username = username;
        this.PasswordHash = passwordHash;
    }
    public User(Guid id, string email, string username, string passwordHash) : base(id)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        DomainException.When(string.IsNullOrEmpty(passwordHash), "PasswordHash cannot be empty");
        
        this.email = email;
        this.Username = username;
        this.PasswordHash = passwordHash;
    }
    public void UpdateUserName(string username)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Username cannot be empty");
        this.Username = username;
    }
}
