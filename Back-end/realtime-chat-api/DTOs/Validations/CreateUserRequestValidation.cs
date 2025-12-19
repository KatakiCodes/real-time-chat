using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class CreateUserRequestValidation : AbstractValidator<CreateUserRequest>, IDisposable
{
    public CreateUserRequestValidation()
    {
        RuleFor(p => p.Email).EmailAddress().NotNull().NotEmpty();
        RuleFor(p => p.Username).NotNull().NotEmpty();
        RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(6);
    }

    public void Dispose()
    {}
}
