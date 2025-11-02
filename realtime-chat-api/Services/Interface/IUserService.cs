using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Services.Interface;

public interface IUserService
{
    public Task<ResponseModel<UserResponse?>> GetByIdAsync(int userId);
    public Task<ResponseModel<UserResponse>> CreateAsync(CreateUserRequest request);
    public Task<ResponseModel<UserResponse>> UpdateUserNameAsync(UpdateUsernameRequest request);
}
