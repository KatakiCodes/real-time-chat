using Microsoft.VisualStudio.TestTools.UnitTesting;
using realtime_chat_api.Entities;
using realtime_chat_api.DomainExceptions;

namespace Company.TestProject1;

[TestClass]
public class EntityTest
{
    private User _user;
    private User _invalid_user;
    private Message _message;
    private Message _invalid_message;
    private Chat _chat;
    private Chat _invalid_chat;

    [TestMethod]
    public void Showld_return_DomainException_on_initializing_an_invalid_user()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            _user = new User("", "username_1", "password_1");
        }, "Email cannot be empty");
        Assert.IsNull(_user);
    }

    [TestMethod]
    public void Showld_return_DomainException_on_creating_an_invalid_chat()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            _chat = new Chat(null, "Friends_Chat"," ABC123");
        },"User cannot be null");
        Assert.IsNull(_chat);
    }

    [TestMethod]
    public void Showld_return_DomainException_on_creating_an_invalid_message()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            _message = new Message(_user, null, "Hello");
        }, "Chat cannot be null");
        Assert.IsNull(_message);
    }

    [TestMethod]
    public void Showld_create_user()
    {
        _user = new User("user_1@gmail.com", "username_1", "password_1");  
        Assert.IsNotNull(_user);
    }

    [TestMethod]
    public void Showld_create_chat()
    {
        _user = new User("user_1@gmail.com", "username_1", "password_1");  
        _chat = new Chat(_user, "Friends_chat"," ABC123");
        Assert.IsNotNull(_chat);
    }

    [TestMethod]
    public void Showld_create_a_message()
    {
        _user = new User("user_1@gmail.com", "username_1", "password_1");  
        _chat = new Chat(_user, "Friends_chat"," ABC123");
        _message = new Message(_user, _chat, "Hello World!");
        Assert.IsNotNull(_message);
    }
}
