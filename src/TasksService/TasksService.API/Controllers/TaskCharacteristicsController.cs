using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksService.Application.Interfaces;

namespace TasksService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskCharacteristicsController(IToDoService toDoService, IJwtUserService jwtUserService) : ControllerBase
{
    private readonly string _userId = jwtUserService.GetUserId();
    
    [HttpPatch("{id}/archive")]
    public async Task<IActionResult> ArchiveTask(string id)
    {
        await toDoService.ArchiveTaskAsync(id, _userId);
        return NoContent();
    }

    [HttpPatch("{id}/restore")]
    public async Task<IActionResult> RestoreTask(string id)
    {
        await toDoService.RestoreTaskAsync(id, _userId);
        return NoContent();
    }
    
    [HttpPatch("{id}/priority")]
    public async Task<IActionResult> SetPriority(string id, [FromQuery] int priority)
    {
        await toDoService.SetPriorityAsync(id, _userId, priority);
        return NoContent();
    }

    [HttpPost("{id}/tags")]
    public async Task<IActionResult> AddTag(string id, [FromQuery] string tag)
    {
        await toDoService.AddTagAsync(id, _userId, tag);
        return NoContent();
    }

    [HttpDelete("{id}/tags")]
    public async Task<IActionResult> RemoveTag(string id, [FromQuery] string tag)
    {
        await toDoService.RemoveTagAsync(id, _userId);
        return NoContent();
    }
    
    [HttpPatch("{id}/deadline")]
    public async Task<IActionResult> SetDeadline(string id, [FromQuery] DateTime? deadline)
    {
        await toDoService.SetDeadlineAsync(id, _userId, deadline);
        return NoContent();
    }
}