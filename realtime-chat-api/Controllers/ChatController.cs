using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using realtime_chat_api.DomainExceptions;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string[]))]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _ChatService;
        private readonly IUserService _UserService;

        public ChatController([FromServices] IChatService chatService, IUserService userService)
        {
            _ChatService = chatService;
            _UserService = userService;
        }

        [Authorize]
        [HttpGet("chats")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<ChatResponse>>> GetByUserId()
        {
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>().UNAUTHORIZED(["Invalid user."]));
                    
                int logedUserId = int.Parse(logedUser);

                var response = await _ChatService.GetByUserIdAsync(logedUserId);
                
                if(response.Success == false)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }

       [Authorize]
        [HttpGet("users/{chatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers(int chatId)
        {
            try
            {
                var response = await _ChatService.GetUsersAsync(chatId);
                
                if(response.Success == false)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<ChatResponse>>> Create([FromBody] CreateChatRequest request)
        {
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>().UNAUTHORIZED(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);

                request.SetUserId(logedUserId);

                var response = await _ChatService.CreateAsync(request);
                if(response.Status != Enums.EResultStatus.CREATED)
                    return StatusCode((int)response.Status, response.Errors);
                return Created("Chat", response.Data);
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<ChatResponse>().BADREQUEST([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }

 
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<ChatResponse>> Update(
            [FromBody] UpdateChatNameRequest request)
        {
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>().UNAUTHORIZED(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);

                var findChat = await _ChatService.GetByIdAsync(request.Id);

                if ((findChat.Data is not null) && (findChat.Data.UserId != logedUserId))
                    return Unauthorized(new ResponseModel<ChatResponse>().UNAUTHORIZED(["Only admin can update chat name."]));

                var response = await _ChatService.UpdateChatNameAsync(request);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<ChatResponse>().BADREQUEST([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
    }
}
