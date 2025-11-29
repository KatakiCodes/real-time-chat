using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class CreateChatRequestValidation : AbstractValidator<CreateChatRequest>, IDisposable
{
    public CreateChatRequestValidation()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();
        RuleFor(p => p.Code).NotNull().NotEmpty().MinimumLength(6);
    }

    public void Dispose()
    {}
}
