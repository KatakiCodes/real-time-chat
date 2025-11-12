using System;
using FluentValidation;
using realtime_chat_api.DTOs.Requests;

namespace realtime_chat_api.DTOs.Validations
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>, IDisposable
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }

        public void Dispose()
        {}
    }
}