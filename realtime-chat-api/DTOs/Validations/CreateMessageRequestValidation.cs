using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class CreateMessageRequestValidation : AbstractValidator<CreateMessageRequest>
{
    public CreateMessageRequestValidation()
    {
        RuleFor(p => p.Content).NotNull().NotEmpty();
        RuleFor(p => p.ChatId).NotNull();
    }
}
