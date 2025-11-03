using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations;

public class UpdateChatNameRequestValidation : AbstractValidator<UpdateChatNameRequest>
{
    public UpdateChatNameRequestValidation()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty();
    }
}
