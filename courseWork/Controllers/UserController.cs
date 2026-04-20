using BLL.Interfaces;
using BLL.Services;
using DTO.Shared;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers;
[ApiController]
[Route("users")]
public class UserController(
    IUserService userService
    ):ControllerBase
{
    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<List<UserDto>>> GetUsers() => Ok(await userService.GetUsers());
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<ResponseWithFilterDto<UserDto>>> GetUsersWithFilter([FromQuery] QueryParamsDto queryParams)
    {
        var filteredUsers = await userService.GetUsersWithFilter(queryParams);

        return Ok(filteredUsers);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid id)=> Ok(await userService.GetUser(id));
    
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody]CreateUserDto user)=> Ok(await userService.CreateUser(user));
    
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(Guid id, [FromBody] UpdateUserDto user)
    {
        user.Id = id;
        
        return Ok(await userService.UpdateUser(user));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await userService.DeleteUser(id);
        return Ok();
    }
}