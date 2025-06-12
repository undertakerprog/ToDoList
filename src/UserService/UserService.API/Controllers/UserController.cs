using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.UseCases.Commands;
using UserService.Application.UseCases.Queries;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var currentUserId = GetCurrentUserId();
        var user = await mediator.Send(new GetUserByIdQuery(currentUserId));
        return Ok(user);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
    {
        var currentUserId = GetCurrentUserId();
        var updatedUser = await mediator.Send(new UpdateUserCommand(id, dto, currentUserId));
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var currentUserId = GetCurrentUserId();
        await mediator.Send(new DeleteUserCommand(id, currentUserId));
        return NoContent();
    }

    [HttpPatch("{id}/make-admin")]
    public async Task<IActionResult> MakeAdmin(int id)
    {
        var currentUserId = GetCurrentUserId();
        await mediator.Send(new MakeAdminCommand(id, currentUserId));
        return Ok();
    }

    private int GetCurrentUserId()
    {
        return 6997;
    }
}