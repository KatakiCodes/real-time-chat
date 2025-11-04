using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class UpdateUsernameRequestValidation : AbstractValidator<UpdateUsernameRequest>, IDisposable
{
    public UpdateUsernameRequestValidation()
    {
        RuleFor(p => p.Username).EmailAddress().NotNull().NotEmpty();
    }

    public void Dispose()
    {}
}
