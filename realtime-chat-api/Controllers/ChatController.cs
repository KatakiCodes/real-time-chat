using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _ChatService;
        public ChatController([FromServices] IChatService chatService)
        {
            _ChatService = chatService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<IEnumerable<ChatResponse>>>> CreateChat([FromBody] CreateChatRequest request)
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

        // GET api/chat/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<ChatResponse>>> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _ChatService.GetByIdAsync(id);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ChatResponse>().INTERNALSERVERERROR(["An unexpected error occured."]));
            }
        }

        // GET api/chat/admin/
        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<IEnumerable<ChatResponse>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<IEnumerable<ChatResponse>>>> GetByAdminId()
        {
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>().UNAUTHORIZED(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);

                var response = await _ChatService.GetByUserIdAsync(logedUserId);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<ChatResponse>().INTERNALSERVERERROR([$"An unexpected error occured. {ex.Message}"]));
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<ChatResponse>>> UpdateChatName(
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
