using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Interfaces;

public interface IMessageInterface
{
    public ResponseModel<Message> Create(CreateMessageDto dto);
    public ResponseModel<Message> EditMessageContent(UpdateMessageDto dto);
}
