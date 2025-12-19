using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;

        public AuthController(IAuthService authService)
        {
            this._AuthService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<UserResponse>> Auth([FromBody]LoginRequest request)
        {
            try
            {
                var response = await _AuthService.Auth(request);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
    }
}
