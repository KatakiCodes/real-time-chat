using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.DTOs.Validations;
using realtime_chat_api.Entities;
using realtime_chat_api.Enums;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class MessageService : IMessageService
{
    private IMessageRepository _Repository;
    private IUser_ChatService _UserChatService;
    private readonly IMapper _Mapper;
    private ResponseModel<MessageResponse> ResponseModel;
    public MessageService(IMapper mapper, IUser_ChatService userChatService, IMessageRepository repository)
    {
        _Repository = repository;
        _UserChatService = userChatService;
        _Mapper = mapper;
        ResponseModel = new();
    }

    public async Task<ResponseModel<MessageResponse>> CreateAsync(CreateMessageRequest request)
    {
        using (var validator = new CreateMessageRequestValidation())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return ResponseModel.BADREQUEST(validationResult.Errors.Select(e => e.ErrorMessage));

            ResponseModel<User_ChatResponse?> findUserChat = await _UserChatService.GetByIdAsync(request.User_ChatId);

            if (findUserChat.Data is null)
                return ResponseModel.UNAUTHORIZED(["Invalid User_Chat."]);
            if(findUserChat.Data.ActivityState != EUserChatActivityState.CAN_INTERACT.ToString())
                return ResponseModel.UNAUTHORIZED(["You cannot interact in this chat"]);

            Message message = _Mapper.Map<Message>(request);
            message = await _Repository.CreateAsync(message);

            var messageResponse = new MessageResponse(message.Id,message.Content,_Mapper.Map<User_ChatResponse>(message.User_Chat),message.Date,message.State);
            return ResponseModel.CREATED(messageResponse);
        }
    }

    public async Task<ResponseModel<MessageResponse>> EditMessageContentAsync(UpdateMessageRequest request)
    {

        using (var validator = new UpdateMessageRequestValidation())
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return ResponseModel.BADREQUEST(validationResult.Errors.Select(e => e.ErrorMessage));

            Message? findMessage = await _Repository.GetByIdAsync(request.Id);
            if (findMessage is null)
                return ResponseModel.NOTFOUND(["Message not found."]);
            findMessage.UpdateContent(request.Content);
            findMessage = await _Repository.UpdateAsync(findMessage);
            return ResponseModel.OK(_Mapper.Map<MessageResponse>(findMessage));
        }

    }

    public async Task<ResponseModel<IEnumerable<MessageResponse>>> GetByChatIdAsync(int chatId)
    {
        ResponseModel<User_ChatResponse?> findUserChat = await _UserChatService.GetByIdAsync(chatId);

        if (findUserChat.Data is null)
            return new ResponseModel<IEnumerable<MessageResponse>>().NOTFOUND(["User_Chat not found."]);

        IEnumerable<Message> messages = await _Repository.GetMessagesByChatIdAsync(chatId);
        List<MessageResponse> response = [];
        foreach (Message message in messages)
            response.Add(_Mapper.Map<MessageResponse>(message));
        return new ResponseModel<IEnumerable<MessageResponse>>().OK(response);
    }

    public async Task<ResponseModel<MessageResponse>?> DeleteMessageAsync(int id)
    {
        var findMessage = await _Repository.GetByIdAsync(id);
        if (findMessage is null)
            return ResponseModel.NOTFOUND(["Message not found."]);
        findMessage.DeleteMessage();
        findMessage = await _Repository.UpdateAsync(findMessage);
        return ResponseModel.OK(_Mapper.Map<MessageResponse>(findMessage))!;
    }
}
