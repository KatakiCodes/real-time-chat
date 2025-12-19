using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;

namespace realtime_chat_api.Services.Interface
{
    public interface IUser_ChatService
    {
        public Task<ResponseModel<User_ChatResponse?>> GetByIdAsync(int id);
        public Task<ResponseModel<IEnumerable<User_ChatResponse>>?> GetByUserId(int userId);
        public Task<ResponseModel<IEnumerable<User_ChatResponse>>> GetByChatId(int chatId);
        public Task<ResponseModel<User_ChatResponse>> GetByChatIdAndUserId(int chatId, int userId);
        public Task<ResponseModel<User_ChatResponse>> CreateAsync(CreateUser_ChatRequest request);
        public Task<ResponseModel<User_ChatResponse>> AllowInteractAsync(int user_chatId);
        public Task<ResponseModel<User_ChatResponse>> SetAsReaderOnly(int user_chatId);
        public Task<ResponseModel<User_ChatResponse>> RemoveAccess(int user_chatId);
        public Task<ResponseModel<User_ChatResponse?>> DeleteAsync(int user_chatId);
    }
}