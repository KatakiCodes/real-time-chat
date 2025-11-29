using System;
using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Mappers;

public class ChatProfile : Profile
{
    public ChatProfile()
    {
        CreateMap<Chat, ChatResponse>();
        CreateMap<CreateChatRequest, Chat>();
        CreateMap<UpdateChatNameRequest, Chat>();
    }
}
