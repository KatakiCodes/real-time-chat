using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class ChatService : IChatService
{
    public ResponseModel<Chat> Create(CreateChatDto dto)
    {
        throw new NotImplementedException();
    }

    public ResponseModel<Chat> UpdateChatName(UpdateChatNameDto dto)
    {
        throw new NotImplementedException();
    }
}
