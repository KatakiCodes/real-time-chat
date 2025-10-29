using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services.Interface;

public interface IChatService
{
    public ResponseModel<Chat> Create(CreateChatDto dto);
    public ResponseModel<Chat> UpdateChatName(UpdateChatNameDto dto);
}
