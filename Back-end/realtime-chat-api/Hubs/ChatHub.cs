using Microsoft.AspNetCore.SignalR;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Hubs.Interface;

namespace realtime_chat_api.Hubs
{
    public class ChatHub : Hub, IChatHub
    {
        public Task SendMessage(MessageResponse message)
        {
            return Clients.All.SendAsync("CreatedMessage", message);
        }
    }
}