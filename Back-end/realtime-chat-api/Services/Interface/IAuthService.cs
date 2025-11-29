using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Services.Interface;

public interface IAuthService
{
    public Task<ResponseModel<LoginResponse?>> Auth(LoginRequest request);
}
