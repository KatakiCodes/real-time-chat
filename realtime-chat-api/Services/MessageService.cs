using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class MessageService : IMessageService
{
    public ResponseModel<Message> Create(CreateMessageDto dto)
    {
        throw new NotImplementedException();
    }

    public ResponseModel<Message> EditMessageContent(UpdateMessageDto dto)
    {
        throw new NotImplementedException();
    }
}
