using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace realtime_chat_api.DTOs.Requests
{
    public record LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}