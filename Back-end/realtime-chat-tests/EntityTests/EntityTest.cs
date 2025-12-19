using Microsoft.VisualStudio.TestTools.UnitTesting;
using realtime_chat_api.Entities;
using realtime_chat_api.DomainExceptions;

namespace Company.TestProject1;

[TestClass]
public class EntityTest
{
    private User _user;
    private Message _message;
    private Chat _chat;
    private User_Chat _user_chat;

    [TestMethod]
    public void Showld_return_DomainException_on_initializing_an_invalid_user()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            _user = new User("", "username_1", BCrypt.Net.BCrypt.HashPassword("password_1"));
        }, "Email cannot be empty");
        Assert.IsNull(_user);
    }

    [TestMethod]
    public void Showld_return_DomainException_on_creating_an_invalid_chat()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            _chat = new Chat(null, "Friends_Chat", BCrypt.Net.BCrypt.HashPassword("ABC123"));
        }, "User cannot be null");
        Assert.IsNull(_chat);
    }

    [TestMethod]
    public void Showld_return_DomainException_on_creating_an_invalid_message()
    {
        _user = new User(1, "user_1@gmail.com", "username_1", BCrypt.Net.BCrypt.HashPassword("password_1"));
        _chat = new Chat(1, _user, "Friends_chat", BCrypt.Net.BCrypt.HashPassword("ABC123"));
        _user_chat = new User_Chat(1, _user.Id, _chat.Id, isAdmin: true);

        Assert.ThrowsException<DomainException>(() =>
        {
            _message = new Message(_user_chat, null);
        }, "Message cannot be null");
        Assert.IsNull(_message);
    }

    [TestMethod]
    public void Showld_create_user()
    {
        _user = new User("user_1@gmail.com", "username_1", BCrypt.Net.BCrypt.HashPassword("password_1"));
        Assert.IsNotNull(_user);
    }

    [TestMethod]
    public void Showld_create_chat()
    {
        _user = new User("user_1@gmail.com", "username_1", BCrypt.Net.BCrypt.HashPassword("password_1"));
        _chat = new Chat(_user, "Friends_chat", BCrypt.Net.BCrypt.HashPassword("ABC123"));

        Assert.IsNotNull(_chat);
        Assert.AreEqual(_chat.Name, "Friends_chat");
        Assert.IsTrue(BCrypt.Net.BCrypt.Verify("ABC123", _chat.Code));
    }

    [TestMethod]
    public void Showld_create_a_message()
    {
        _user = new User(1, "user_1@gmail.com", "username_1", BCrypt.Net.BCrypt.HashPassword("password_1"));
        _chat = new Chat(1, _user, "Friends_chat", " ABC123");
        _user_chat = new User_Chat(1, _user.Id, _chat.Id, isAdmin: true);
        _message = new Message(_user_chat, "Hello World!");
        Assert.IsNotNull(_message);
    }
}
