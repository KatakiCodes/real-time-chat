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
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController([FromServices] IUserService userService)
        {
            _UserService = userService;
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> GetById([FromRoute]int id)
        {
            try
            {
                var response = await _UserService.GetByIdAsync(id);
                return StatusCode((int)response.Status, response.Data);
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var operationResult = await _UserService.CreateAsync(request);
                return StatusCode((int)operationResult.Status, operationResult.Data);
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<UserResponse>().BADREQUEST([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<UserResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> UpdateUserName([FromBody] UpdateUsernameRequest request)
        {
            try
            {
                int tryGetUserId = int.Parse(User.FindFirst("sub")?.Value ?? "0");
                if (tryGetUserId == 0)
                    return Unauthorized(new ResponseModel<UserResponse>().UNAUTHORIZED(["Invalid token."]));
                    
                request.SetUserId(tryGetUserId);

                var operationResult = await _UserService.UpdateUserNameAsync(request);

                return StatusCode((int)operationResult.Status, operationResult.Data);
            }
            catch(DomainException ex)
            {
                return BadRequest(new ResponseModel<UserResponse>().BADREQUEST([ex.Message]));
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel<UserResponse>().INTERNALSERVERERROR(["An unexpected error occurred."]));
            }
        }
    }
}
