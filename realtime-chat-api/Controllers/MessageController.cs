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
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _MessageService;

        public MessageController([FromServices] IMessageService messageService)
        {
            _MessageService = messageService;
        }

        [HttpGet("chat/{chatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<MessageResponse>>> GetByChatId([FromRoute] int chatId)
        {
            try
            {
                var response = await _MessageService.GetByChatIdAsync(chatId);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<MessageResponse>().INTERNALSERVERERROR([$"An unexpected error occurred. {ex.Message}"]));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        public async Task<ActionResult<MessageResponse>> Create([FromBody] CreateMessageRequest request)
        {
            try
            {
                var response = await _MessageService.CreateAsync(request);

                if(response.Status != Enums.EResultStatus.CREATED)
                    return StatusCode((int)response.Status, response.Errors);
                return Created("Message", response.Data);
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<MessageResponse>().BADREQUEST([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<MessageResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        public async Task<ActionResult<MessageResponse>> Update([FromBody] UpdateMessageRequest request)
        {
            try
            {
                var logedUserId = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (logedUserId is null)
                    return Unauthorized(new ResponseModel<MessageResponse>().UNAUTHORIZED(["Invalid user."]));

                var response = await _MessageService.EditMessageContentAsync(request);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<MessageResponse>().BADREQUEST([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<MessageResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
        [HttpDelete("{messageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<MessageResponse>>> Delete([FromRoute] int messageId)
        {
            try
            {
                var response = await _MessageService.DeleteMessageAsync(messageId);
                if(response.Success == false)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<MessageResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
    }
}
