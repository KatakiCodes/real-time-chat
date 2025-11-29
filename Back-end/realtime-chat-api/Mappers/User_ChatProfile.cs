using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Mappers
{
    public class User_ChatProfile : Profile
    {
        public User_ChatProfile()
        {
            CreateMap<User_Chat,User_ChatResponse>();
            CreateMap<CreateUser_ChatRequest,User_Chat>();
        }
    }
}