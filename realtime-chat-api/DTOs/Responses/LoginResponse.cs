namespace realtime_chat_api.DTOs.Responses
{
    public record LoginResponse
    {
        public LoginResponse(string token) => Token = token;

        public string Token { get; private set; }
    }
}