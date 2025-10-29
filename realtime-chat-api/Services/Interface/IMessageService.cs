using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IMessageService
{
    public ResponseModel<Message> Create(CreateMessageDto dto);
    public ResponseModel<Message> EditMessageContent(UpdateMessageDto dto);
}
