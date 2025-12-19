using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Hubs.Interface
{
    public interface IChatHub
    {
        Task SendMessage(MessageResponse message);
    }
}