using System;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Services.Interface;

public interface IMessageService
{
    public Task<ResponseModel<IEnumerable<MessageResponse>>> GetByChatIdAsync(int chatId);
    public Task<ResponseModel<MessageResponse>> CreateAsync(CreateMessageRequest request);
    public Task<ResponseModel<MessageResponse>> EditMessageContentAsync(UpdateMessageRequest request);
}
