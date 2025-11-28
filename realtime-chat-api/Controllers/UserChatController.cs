using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using realtime_chat_api.DTOs.Requests;
using realtime_chat_api.DTOs.Responses;
using realtime_chat_api.Enums;
using realtime_chat_api.Services.Interface;

namespace realtime_chat_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
    public class UserChatController : ControllerBase
    {
        private readonly IUser_ChatService _User_ChatService;

        public UserChatController(IUser_ChatService user_ChatService)
        {
            _User_ChatService = user_ChatService;
        }

        [HttpGet("{userchatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User_ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<User_ChatResponse>>> GetById([FromRoute]int userchatId)
        {
            try
            {
                
                var response = await _User_ChatService.GetByIdAsync(userchatId);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }



        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User_ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<User_ChatResponse>> Create([FromBody]CreateUser_ChatRequest request)
        {
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["Invalid user."]));

                int logedUserId = int.Parse(logedUser);
                var requestIsAdminfalse = request with {IsAdmin = false};
                var response = await _User_ChatService.CreateAsync(requestIsAdminfalse);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }

        [HttpPut("allow-interact/{userchatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<User_ChatResponse>> AllowInteract([FromRoute] int userchatId)
        {
            var responseModel = new ResponseModel<IEnumerable<User_ChatResponse>>();
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(responseModel.Errors);

                int logedUserId = int.Parse(logedUser);
                var response = await _User_ChatService.AllowInteractAsync(userchatId);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }

        [HttpPut("setas-readeronly/{userchatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<User_ChatResponse>>> SetAsReaderOnly([FromRoute] int userchatId)
        {
            var responseModel = new ResponseModel<IEnumerable<User_ChatResponse>>();
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(responseModel.Errors);

                int logedUserId = int.Parse(logedUser);
                var response = await _User_ChatService.SetAsReaderOnly(userchatId);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }       

        [HttpPut("remove-access/{userchatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<User_ChatResponse>>> RemoveAccess([FromRoute] int userchatId)
        {
            var responseModel = new ResponseModel<IEnumerable<User_ChatResponse>>();
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(responseModel.Errors);

                int logedUserId = int.Parse(logedUser);
                var response = await _User_ChatService.RemoveAccess(userchatId);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }   

        [HttpDelete("{userchatId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChatResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string[]))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<User_ChatResponse>>> Delete([FromRoute]int userchatId)
        {
            var responseModel = new ResponseModel<IEnumerable<User_ChatResponse>>();
            try
            {
                var logedUser = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (logedUser is null)
                    return Unauthorized(responseModel.Errors);

                int logedUserId = int.Parse(logedUser);
                var response = await _User_ChatService.DeleteAsync(userchatId);
                
                if(response.Status != EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return Ok(null);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new ResponseModel<User_ChatResponse>().UNAUTHORIZED(["An unexpected error occured."]));
            }
        }
    }
}
