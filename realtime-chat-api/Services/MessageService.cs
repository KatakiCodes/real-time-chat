using System;
using AutoMapper;
using realtime_chat_api.DomainExceptions;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class MessageService : IMessageService
{
    private IMessageRepository _Repository;
    private IUserService _UserService;
    private IChatService _ChatService;
    private readonly IMapper _Mapper;
    private ResponseModel<MessageResponse> ResponseModel;
    public MessageService(IMapper mapper,IUserService userService,IChatService chatService,IMessageRepository repository)
    {
        _Repository = repository;
        _UserService = userService;
        _ChatService = chatService;
        _Mapper = mapper;
        ResponseModel = new();
    }

    public async Task<ResponseModel<MessageResponse>> CreateAsync(CreateMessageRequest request)
    {
        ResponseModel<UserResponse?> findUser = await _UserService.GetByIdAsync(request.GetUserId());
        ResponseModel<ChatResponse?> findChat = await _ChatService.GetByIdAsync(request.ChatId);
        if (findUser.Data is null)
            return ResponseModel.UNAUTHORIZED(["Invalid User."]);
        if (findChat.Data is null)
            return ResponseModel.NOTFOUND(["Chat not found."]);
        Message message = _Mapper.Map<Message>(request);
        message = await _Repository.CreateAsync(message);
        return ResponseModel.CREATED(_Mapper.Map<MessageResponse>(message));
    }

    public async Task<ResponseModel<MessageResponse>> EditMessageContentAsync(UpdateMessageRequest request)
    {
        Message? findMessage = await _Repository.GetByIdAsync(request.Id);
        if(findMessage is null)
            return ResponseModel.NOTFOUND(["Message not found."]);
        findMessage.UpdateContent(request.Content);
        findMessage = await _Repository.UpdateAsync(findMessage);
        return ResponseModel.OK(_Mapper.Map<MessageResponse>(findMessage));
    }

    public async Task<ResponseModel<IEnumerable<MessageResponse>>> GetByChatIdAsync(int chatId)
    {
        ResponseModel<ChatResponse?> findChat =  await _ChatService.GetByIdAsync(chatId);
        if (findChat.Data is null)
            return new ResponseModel<IEnumerable<MessageResponse>>().NOTFOUND(["Chat not found."]);
        IEnumerable<Message> messages = await _Repository.GetMessagesByChatIdAsync(chatId);
        List<MessageResponse> response = [];
        foreach (Message message in messages)
            response.Add(_Mapper.Map<MessageResponse>(message));
            return new ResponseModel<IEnumerable<MessageResponse>>().OK(response);
    }
}
