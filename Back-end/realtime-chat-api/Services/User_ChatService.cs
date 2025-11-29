using AutoMapper;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Repositories.Interface;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Services
{
    public class User_ChatService : IUser_ChatService
    {
        private readonly IUser_ChatRepository _Repository;
        private readonly IMapper _Mapper;
        public ResponseModel<User_ChatResponse> ResponseModel;

        public User_ChatService(IUser_ChatRepository repository, IMapper mapper)
        {
            _Repository = repository;
            ResponseModel = new();
            _Mapper = mapper;
        }

        public async Task<ResponseModel<User_ChatResponse>> AllowInteractAsync(int user_chatId)
        {
            var findUser_chat = await _Repository.GetByIdAsync(user_chatId);
            if(findUser_chat is null)
                return ResponseModel.NOTFOUND(["user_chat not found."]);

            findUser_chat.AllowInteract();

            findUser_chat = await _Repository.UpdateAsync(findUser_chat);

            return ResponseModel.OK(_Mapper.Map<User_ChatResponse>(findUser_chat));
        }

        public async Task<ResponseModel<User_ChatResponse>> CreateAsync(CreateUser_ChatRequest request)
        {                
            var user_chatCreate = await _Repository.CreateAsync(_Mapper.Map<User_Chat>(request));
            return ResponseModel.CREATED(_Mapper.Map<User_ChatResponse>(user_chatCreate));
        }

        public async Task<ResponseModel<User_ChatResponse>> DeleteAsync(int user_chatId)
        {
            var findUser_chat = await _Repository.GetByIdAsync(user_chatId);
            if(findUser_chat is null)
                return ResponseModel.NOTFOUND(["User_chat not found."]);
                
            await _Repository.Delete(findUser_chat);
            return ResponseModel.OK(null);
        }

        public async Task<ResponseModel<IEnumerable<User_ChatResponse>>> GetByChatId(int chatId)
        {
            var findByChatId = await _Repository.GetByChatIdAsync(chatId);
            List<User_ChatResponse> mapUserChats = [];

            foreach(var user_chat in findByChatId)
                mapUserChats.Add(_Mapper.Map<User_ChatResponse>(user_chat));

            return new ResponseModel<IEnumerable<User_ChatResponse>>().OK(mapUserChats);
        }

        public async Task<ResponseModel<User_ChatResponse>> GetByChatIdAndUserId(int chatId, int userId)
        {
            var findByChatIdAndUserId = await _Repository.GetByChatIdAndUserIdAsync(chatId, userId);

            if(findByChatIdAndUserId is null)
            return ResponseModel.NOTFOUND(["No user_chat found for the given chatId and userId."]);

            var mapUserChat = _Mapper.Map<User_ChatResponse>(findByChatIdAndUserId);

            return ResponseModel.OK(mapUserChat);
        }

        public async Task<ResponseModel<User_ChatResponse>> GetByIdAsync(int id)
        {
            var findUser_chat = await _Repository.GetByIdAsync(id);
            if(findUser_chat is null)
                return ResponseModel.NOTFOUND(["user_chat not found."]);

            var mapUserChat = _Mapper.Map<User_ChatResponse>(findUser_chat);
            return ResponseModel.OK(mapUserChat);
        }

        public async Task<ResponseModel<IEnumerable<User_ChatResponse>>?> GetByUserId(int userId)
        {
            var findByUserId = await _Repository.GetByUserIdAsync(userId);
            List<User_ChatResponse> mapUserChats = [];

            foreach(var user_chat in findByUserId)
                mapUserChats.Add(_Mapper.Map<User_ChatResponse>(user_chat));

            return new ResponseModel<IEnumerable<User_ChatResponse>>().OK(mapUserChats);
        }


        public async Task<ResponseModel<User_ChatResponse>> RemoveAccess(int user_chatId)
        {
            var findUser_chat = await _Repository.GetByIdAsync(user_chatId);
            if(findUser_chat is null)
                return ResponseModel.NOTFOUND(["user_chat not found."]);

            findUser_chat.RemoveAccess();

            findUser_chat = await _Repository.UpdateAsync(findUser_chat);

            return ResponseModel.OK(_Mapper.Map<User_ChatResponse>(findUser_chat));
        }

        public async Task<ResponseModel<User_ChatResponse>> SetAsReaderOnly(int user_chatId)
        {
            var findUser_chat = await _Repository.GetByIdAsync(user_chatId);
            if(findUser_chat is null)
                return ResponseModel.NOTFOUND(["user_chat not found."]);

            findUser_chat.SetAsReaderOnly();

            findUser_chat = await _Repository.UpdateAsync(findUser_chat);

            return ResponseModel.OK(_Mapper.Map<User_ChatResponse>(findUser_chat));
        }

    }
}