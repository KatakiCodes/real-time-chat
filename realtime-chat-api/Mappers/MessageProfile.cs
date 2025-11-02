using System;
using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Mappers;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageResponse>();
        CreateMap<CreateMessageRequest, Message>();
        CreateMap<UpdateMessageRequest, Message>();
    }
}
