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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController([FromServices] IUserService userService)
        {
            _UserService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> Auth([FromBody]LoginRequest request)
        {
            try
            {
                var response = await _UserService.Login(request);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _UserService.GetByIdAsync(id);
                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _UserService.CreateAsync(request);
                if(response.Status != Enums.EResultStatus.CREATED)
                    return StatusCode((int)response.Status, response.Errors);
                return Created("User",response.Data);
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> UpdateUserName([FromBody] UpdateUsernameRequest request)
        {
            try
            {
                string? tryGetUserId = User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (tryGetUserId is null)
                    return Unauthorized(new ResponseModel<UserResponse>().UNAUTHORIZED(["Invalid token."]));

                request.SetUserId(int.Parse(tryGetUserId));

                var response = await _UserService.UpdateUserNameAsync(request);

                if(response.Status != Enums.EResultStatus.OK)
                    return StatusCode((int)response.Status, response.Errors);
                return StatusCode((int)response.Status, response.Data);
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
    }
}
