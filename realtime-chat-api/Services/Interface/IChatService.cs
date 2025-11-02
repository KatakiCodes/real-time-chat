using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Services.Interface;

public interface IChatService
{
    public Task<ResponseModel<ChatResponse?>> GetByIdAsync(int chatId);
    public Task<ResponseModel<IEnumerable<ChatResponse>>> GetByUserIdAsync(int userId);
    public Task<ResponseModel<ChatResponse>> CreateAsync(CreateChatRequest request);
    public Task<ResponseModel<ChatResponse>> UpdateChatNameAsync(UpdateChatNameRequest request);
}
