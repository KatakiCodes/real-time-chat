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
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _MessageService;

        public MessageController([FromServices] IMessageService messageService)
        {
            _MessageService = messageService;
        }

        [HttpGet("chat/{chatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<IEnumerable<MessageResponse>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseModel<IEnumerable<MessageResponse>>))]
        public async Task<ActionResult<ResponseModel<IEnumerable<MessageResponse>>>> GetByChatId([FromRoute] int chatId)
        {
            var messages = await _MessageService.GetByChatIdAsync(chatId);
            if (messages is null)
                return NotFound(new ResponseModel<MessageResponse>(["Chat not found."]));
            MessageResponse[] response = [.. messages.Select(m => new MessageResponse(m.Id,m.Content,m.UserId,m.Chat.Id,m.Date
            ))];
            return Ok(new ResponseModel<IEnumerable<MessageResponse>>(true, response));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<Message>>> Create([FromBody] CreateMessageRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseModel<Message>([.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            
            try
            {
                var logedUser = User.FindFirst(c => c.Type == "sub")?.Value;
                if (logedUser is null)
                    return Unauthorized(new ResponseModel<Message>(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);
                request.SetUserId(logedUserId);

                var messageCreate = await _MessageService.CreateAsync(request);
                MessageResponse response = new(
                    messageCreate.Id,
                    messageCreate.Content,
                    messageCreate.UserId,
                    messageCreate.Chat.Id,
                    messageCreate.Date
                );
                return StatusCode(201, new ResponseModel<MessageResponse>(true, response));
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<Message>([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<Message>(["An unexpected error occurred."]));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<Message>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<Message>>> EditContent([FromBody] UpdateMessageDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseModel<Message>([.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            
            try
            {
                var logedUserId = User.FindFirst(c => c.Type == "sub")?.Value;
                if (logedUserId is null)
                    return Unauthorized(new ResponseModel<Message>(["Invalid user."]));

                var message = new Message(int.Parse(logedUserId), dto.ChatId, dto.Content) { Id = dto.Id };
                var updatedMessage = await _MessageService.EditMessageContentAsync(message);
                return Ok(new ResponseModel<Message>(true, updatedMessage));
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<Message>([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<Message>(["An unexpected error occurred."]));
            }
        }
    }
}
