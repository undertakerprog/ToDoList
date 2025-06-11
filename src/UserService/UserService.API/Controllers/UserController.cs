using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var currentUserId = GetCurrentUserId();
        var user = await userService.GetUserByIdAsync(currentUserId);
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
    {
        var currentUserId = GetCurrentUserId();
        var updatedUser = await userService.UpdateUserAsync(dto, currentUserId);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var currentUserId = GetCurrentUserId();
        await userService.DeleteUserAsync(id, currentUserId);
        return NoContent();
    }

    [HttpPatch("{id}/make-admin")]
    public async Task<IActionResult> MakeAdmin(int id)
    {
        var currentUserId = GetCurrentUserId();
        await userService.MakeAdminAsync(id, currentUserId);
        return Ok();
    }

    private int GetCurrentUserId()
    {
        return 1;
    }
}