using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Interfaces;

public interface IUserInterface
{
    public ResponseModel<User> Create(CreateUserDto dto);
    public ResponseModel<User> UpdateUserName(UpdateUsernameDto dto);
}
