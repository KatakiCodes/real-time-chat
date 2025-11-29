using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class UpdateMessageRequestValidation : AbstractValidator<UpdateMessageRequest>, IDisposable
{
    public UpdateMessageRequestValidation()
    {
        RuleFor(p => p.Content).NotEmpty().NotNull();
    }

    public void Dispose()
    {}
}
