using System;
using realtime_chat_api.DomainExceptions;
namespace realtime_chat_api.Entities;

public class User : Entity
{
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public List<Chat> AdministeredChats { get; private set; }

    public User()
    { }

    public User(string email, string username, string password)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        DomainException.When(string.IsNullOrEmpty(password), "Password cannot be empty");

        this.Email = email;
        this.Username = username;
        this.Password = password;
    }
    public User(int id, string email, string username, string password) : base(id)
    {
        DomainException.When(string.IsNullOrEmpty(email), "Email cannot be empty");
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        DomainException.When(string.IsNullOrEmpty(password), "Password cannot be empty");
        
        this.Email = email;
        this.Username = username;
        this.Password = password;
    }
    public void UpdateUserName(string username)
    {
        DomainException.When(string.IsNullOrEmpty(username), "Username cannot be empty");
        this.Username = username;
    }
}
