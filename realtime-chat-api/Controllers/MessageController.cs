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
            try
            {
                var operationResult = await _MessageService.GetByChatIdAsync(chatId);
                return StatusCode((int)operationResult.Status, operationResult.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<MessageResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<MessageResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<MessageResponse>>> Create([FromBody] CreateMessageRequest request)
        {
            try
            {
                var logedUser = User.FindFirst(c => c.Type == "sub")?.Value;
                if (logedUser is null)
                    return Unauthorized(new ResponseModel<MessageResponse>().UNAUTHORIZED(["Invalid user."]));
                int logedUserId = int.Parse(logedUser);
                request.SetUserId(logedUserId);

                var operationResult = await _MessageService.CreateAsync(request);

                return StatusCode((int)operationResult.Status,operationResult.Data);
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<MessageResponse>>> EditContent([FromBody] UpdateMessageRequest request)
        {
            try
            {
                var logedUserId = User.FindFirst(c => c.Type == "sub")?.Value;
                if (logedUserId is null)
                    return Unauthorized(new ResponseModel<MessageResponse>().UNAUTHORIZED(["Invalid user."]));

                var operationResult = await _MessageService.EditMessageContentAsync(request);
                return StatusCode((int)operationResult.Status, operationResult.Data);
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
    }
}
