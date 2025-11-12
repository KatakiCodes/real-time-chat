using System;
using AutoMapper;
using FluentValidation.Results;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.DTOs.Validations;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _Repository;
    private readonly IMapper _Mapper;
    private readonly IConfiguration _Configuration;
    private ResponseModel<UserResponse?> ResponseModel;
    public UserService(IConfiguration configuration,IMapper mapper, IUserRepository repository)
    {
        _Repository = repository;
        _Mapper = mapper;
        ResponseModel = new();
        _Configuration = configuration;
    }

    public async Task<ResponseModel<UserResponse?>> CreateAsync(CreateUserRequest request)
    {
        using (CreateUserRequestValidation validator = new())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return ResponseModel.BADREQUEST(validationResult.Errors.Select(x => x.ErrorMessage));

            var withPasswordHash = request with { Password = BCrypt.Net.BCrypt.HashPassword(request.Password) };
            User user = _Mapper.Map<User>(withPasswordHash);
            user = await _Repository.CreateAsync(user);
            UserResponse response = _Mapper.Map<UserResponse>(withPasswordHash);
            return ResponseModel.CREATED(response)!;
        }
    }

    public async Task<ResponseModel<UserResponse?>> GetByIdAsync(int userId)
    {
        User? findUser = await _Repository.GetByIdAsync(userId);
        if (findUser is null)
            return ResponseModel.NOTFOUND(["User not found."]);
        return ResponseModel.OK(_Mapper.Map<UserResponse>(findUser));
    }

    public async Task<ResponseModel<LoginResponse?>> Login(LoginRequest request)
    {
        ResponseModel<LoginResponse?> response = new();
        using(var validator = new LoginRequestValidation())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return response.BADREQUEST(validationResult.Errors.Select(x => x.ErrorMessage))!;
            var findUser = await _Repository.GetUserByEmailAsync(request.Email);
            if ((findUser is null) || (BCrypt.Net.BCrypt.Verify(request.Email, findUser.Password) == false))
                return response.UNAUTHORIZED(["Email or Password invalid."]);
            var loginResponse = new LoginResponse(new TokenService(this._Configuration).Generate(findUser));
            return response.OK(loginResponse);
        }
    }

    public async Task<ResponseModel<UserResponse?>>UpdateUserNameAsync(UpdateUsernameRequest request)
    {
        User? findUser = await _Repository.GetByIdAsync(request.GetUserId());

        if (findUser is null)
            return ResponseModel.NOTFOUND(["User not found."]);
            
        using(var validator = new UpdateUsernameRequestValidation())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return ResponseModel.BADREQUEST(validationResult.Errors.Select(x => x.ErrorMessage));
            findUser.UpdateUserName(request.Username);
            await _Repository.UpdateAsync(findUser);
            UserResponse response = _Mapper.Map<UserResponse>(findUser);

            return ResponseModel.OK(response);
        }
    }
}
