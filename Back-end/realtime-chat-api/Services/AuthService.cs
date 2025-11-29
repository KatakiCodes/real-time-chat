using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.DTOs.Validations;
using realtime_chat_api.Repositories;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _Repository;
    private readonly IConfiguration _Configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        this._Repository = userRepository;
        this. _Configuration = configuration;
    }

    public async Task<ResponseModel<LoginResponse>> Auth(LoginRequest request)
    {
        ResponseModel<LoginResponse> response = new();
        using(var validator = new LoginRequestValidation())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return response.BADREQUEST([""])!;
            var findUser = await _Repository.GetUserByEmailAsync(request.Email);
            if ((findUser is null) || (BCrypt.Net.BCrypt.Verify(request.Password, findUser.Password) == false))
                return response.UNAUTHORIZED(["Email or Password invalid."]);
            var loginResponse = new LoginResponse(new TokenService(this._Configuration).Generate(findUser));
            return response.OK(loginResponse);
        }
    }
}
