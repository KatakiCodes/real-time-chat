using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using realtime_chat_api.Entities;

namespace realtime_chat_api.Services
{
    public class TokenService
    {
        private readonly JwtSecurityTokenHandler _TokenHandler;

        private readonly IConfiguration _Configuration;

        public TokenService(IConfiguration configuration)
        {
            _TokenHandler = new();
            _Configuration = configuration;
        }

        public string Generate(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(this._Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaimsFromUser(user)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(1)
            };
            var token = this._TokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return this._TokenHandler.WriteToken(token);
        }
        private List<Claim> GetClaimsFromUser(User user)
        {
            List<Claim> claims = [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username)
                ];
            return claims;
        }
    }
}