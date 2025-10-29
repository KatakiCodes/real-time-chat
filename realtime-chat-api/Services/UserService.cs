using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class UserService : IUserService
{
    public ResponseModel<User> Create(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }

    public ResponseModel<User> UpdateUserName(UpdateUsernameDto dto)
    {
        throw new NotImplementedException();
    }
}
