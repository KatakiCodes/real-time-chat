using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using realtime_chat_api.DomainExceptions;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Entities;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (!ModelState.IsValid)
                return BadRequest(new ResponseModel<ChatResponse>([.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            try
            {
                var logedUser = User.FindFirst(c => c.Type == "sub")?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);

                request.SetUserId(logedUserId);
                Chat chatCreate = await _ChatService.CreateAsync(request);
                ChatResponse response = new(chatCreate.Id,chatCreate.AdminId, chatCreate.Name);
                return StatusCode(201, new ResponseModel<ChatResponse>(true, response));
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<ChatResponse>([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<ChatResponse>(["An unexpected error occurred."]));
            }
        }

        // GET api/chat/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<ChatResponse>>> GetById([FromRoute] int id)
        {
            var findChat = await _ChatService.GetByIdAsync(id);
            if (findChat is null)
                return NotFound(new ResponseModel<ChatResponse>(["Chat not found."]));
            ChatResponse response = new(findChat.Id, findChat.AdminId, findChat.Name);
            return Ok(new ResponseModel<ChatResponse>(true, response));
        }

        // GET api/chat/admin/{adminId}
        [HttpGet("admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<IEnumerable<ChatResponse>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<IEnumerable<ChatResponse>>>> GetByAdminId()
        {
            var logedUser = User.FindFirst(c => c.Type == "sub")?.Value;
                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);
            var chats = await _ChatService.GetByUserIdAsync(logedUserId);
            ChatResponse[] response = [.. chats.Select(c => new ChatResponse(c.Id, c.AdminId, c.Name))];
            return Ok(new ResponseModel<IEnumerable<ChatResponse>>(true, response));
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<ChatResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<Chat>>> UpdateChatName(
            [FromBody] UpdateChatNameRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseModel<Chat>(
                    [.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            
            try 
            {
                var logedUser = User.FindFirst(c => c.Type == "sub")?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<ChatResponse>(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);

                var chat = await _ChatService.GetByIdAsync(request.Id);
                if (chat is null)
                    return NotFound(new ResponseModel<ChatResponse>(["Chat not found."]));

                if (chat.AdminId != logedUserId)
                    return Unauthorized(new ResponseModel<ChatResponse>(["Only admin can update chat name."]));

                var chatUpdate = await _ChatService.UpdateChatNameAsync(request);
                if(chatUpdate is null)
                    return NotFound(new ResponseModel<ChatResponse>(["Chat not found."]));
                ChatResponse response = new(chatUpdate!.Id, chatUpdate.AdminId, chatUpdate.Name);
                return Ok(new ResponseModel<ChatResponse>(true, response));
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<Chat>([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<Chat>(["An unexpected error occurred."]));
            }
        }
    }
}
