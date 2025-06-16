using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Services;
using UserService.Application.UseCases.Commands;
using UserService.Application.DTOs;
using UserService.Application.UseCases.Queries;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IMediator mediator, IdentityService identityService) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
    {
        var (currentUserId, currentUserRole) = identityService.GetUserIdentity();
        Console.WriteLine($"UpdateUser: currentUserId={currentUserId}, role={currentUserRole}");
        try
        {
            var updatedUser = await mediator.Send(new UpdateUserCommand(int.Parse(currentUserId), dto, currentUserId));
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"UpdateUser error: {ex.Message}");
            throw;
        }
    }

    private (object currentUserId, object currentUserRole) GetUserIdentity()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var (currentUserId, currentUserRole) = identityService.GetUserIdentity();
        Console.WriteLine($"DeleteUser: id={id}, currentUserId={currentUserId}, role={currentUserRole}");
        try
        {
            await mediator.Send(new DeleteUserCommand(id, currentUserId, currentUserRole));
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"DeleteUser error: {ex.Message}");
            throw;
        }
    }

    [HttpPatch("{id}/make-admin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> MakeAdmin(int id)
    {
        var (currentUserId, currentUserRole) = identityService.GetUserIdentity();
        Console.WriteLine($"MakeAdmin: id={id}, currentUserId={currentUserId}, role={currentUserRole}");
        try
        {
            await mediator.Send(new MakeAdminCommand(id, currentUserId, currentUserRole));
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"MakeAdmin error: {ex.Message}");
            throw;
        }
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var (currentUserId, currentUserRole) = identityService.GetUserIdentity();
        Console.WriteLine($"GetCurrentUser: currentUserId={currentUserId}, role={currentUserRole}");
        try
        {
            var user = await mediator.Send(new GetUserByIdQuery(int.Parse(currentUserId)));
            if (user == null) throw new Exception("User not found");
            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetCurrentUser error: {ex.Message}");
            throw;
        }
    }
}