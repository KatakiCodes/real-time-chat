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
                var findUser = await _UserService.GetByIdAsync(id);
                if (findUser is null)
                    return NotFound("User not found.");
                UserResponse response = new(findUser.Id, findUser.Username, findUser.Email);
                return Ok(new ResponseModel<UserResponse>(true, response));
            }
            catch(Exception){
                return StatusCode(500, new ResponseModel<UserResponse>(["An unexpected error occurred."]));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseModel<UserResponse>([.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            try
            {
                User userCreated = await _UserService.CreateAsync(request);
                UserResponse response = new(userCreated.Id, userCreated.Username, userCreated.Email);
                return StatusCode(201, new ResponseModel<UserResponse>(true, response));
            }
            catch (DomainException ex)
            {
                return BadRequest(new ResponseModel<UserResponse>([ex.Message]));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResponseModel<UserResponse>(["An unexpected error occurred."]));
            }
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseModel<UserResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseModel<UserResponse>>> UpdateUserName([FromBody] UpdateUsernameRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResponseModel<UserResponse>([.. ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)]));
            try
            {
                int tryGetUserId = int.Parse(User.FindFirst("sub")?.Value ?? "0");
                if (tryGetUserId == 0)
                    return Unauthorized(new ResponseModel<UserResponse>(["Invalid token."]));
                    
                request.SetUserId(tryGetUserId);

                User? userUpdate = await _UserService.UpdateUserNameAsync(request);

                if (userUpdate is null)
                    return NotFound("User not found.");

                UserResponse response = new(userUpdate.Id, userUpdate.Username, userUpdate.Email);
                return Ok(new ResponseModel<UserResponse>(true, response));
            }
            catch(DomainException ex)
            {
                return BadRequest(new ResponseModel<UserResponse>([ex.Message]));
            }
            catch(Exception){
                return StatusCode(500, new ResponseModel<UserResponse>(["An unexpected error occurred."]));
            }
        }
    }
}
