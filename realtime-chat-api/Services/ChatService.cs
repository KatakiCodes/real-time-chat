using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _Repository;
    private readonly IUserService _UserService;
    private readonly IMapper _Mapper;
    private ResponseModel<ChatResponse?> ResponseModel;

    public ChatService(IMapper mapper,IUserService userService,IChatRepository repository)
    {
        _Repository = repository;
        _UserService = userService;
        _Mapper = mapper;
        ResponseModel = new();
    }

    public async Task<ResponseModel<ChatResponse?>> CreateAsync(CreateChatRequest request)
    {
        ResponseModel<UserResponse?> findUser = await _UserService.GetByIdAsync(request.GetUserId());
        if (findUser.Data is null)
            return ResponseModel.UNAUTHORIZED(["Invalid user"]);
        Chat chat = _Mapper.Map<Chat>(request);
        chat = await _Repository.CreateAsync(chat);
        return ResponseModel.CREATED(_Mapper.Map<ChatResponse>(chat));
    }

    public async Task<ResponseModel<ChatResponse?>> GetByIdAsync(int chatId)
    {
        Chat? findChat = await _Repository.GetByIdAsync(chatId);
        if (findChat is null)
            return ResponseModel.NOTFOUND(["Chat not found."]);
        return ResponseModel.OK(_Mapper.Map<ChatResponse>(findChat));
    }
    public async Task<ResponseModel<IEnumerable<ChatResponse>>> GetByUserIdAsync(int userId)
    {
        IEnumerable<Chat> chats = await _Repository.GetChatsByUserIdAsync(userId);
        List<ChatResponse> responseList = new List<ChatResponse>();
        foreach (Chat chat in chats)
            responseList.Add(_Mapper.Map<ChatResponse>(chat));
        return new ResponseModel<IEnumerable<ChatResponse>>().OK(responseList);
    }

    public async Task<ResponseModel<ChatResponse?>> UpdateChatNameAsync(UpdateChatNameRequest request)
    {
        Chat? findChat = await _Repository.GetByIdAsync(request.Id);
        if(findChat is null)
            return ResponseModel.NOTFOUND(["Chat not found."]);

        findChat.UpdateChatName(request.Name);
        return ResponseModel.OK(_Mapper.Map<ChatResponse>(findChat));
    }
}
