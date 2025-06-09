using Microsoft.AspNetCore.Mvc;
using TasksService.Application.Interfaces;

namespace TasksService.API.Controllers;

public class TaskCharacteristicsController(IToDoService toDoService) : ControllerBase
{
    [HttpPatch("{id}/archive")]
    public async Task<IActionResult> ArchiveTask(string id)
    {
        var userId = "test-user"; 
        await toDoService.ArchiveTaskAsync(id, userId);
        return NoContent();
    }

    [HttpPatch("{id}/restore")]
    public async Task<IActionResult> RestoreTask(string id)
    {
        var userId = "test-user"; 
        await toDoService.RestoreTaskAsync(id, userId);
        return NoContent();
    }
    
    [HttpPatch("{id}/priority")]
    public async Task<IActionResult> SetPriority(string id, [FromQuery] int priority)
    {
        var userId = "test-user";
        await toDoService.SetPriorityAsync(id, userId, priority);
        return NoContent();
    }

    [HttpPost("{id}/tags")]
    public async Task<IActionResult> AddTag(string id, [FromQuery] string tag)
    {
        var userId = "test-user";
        await toDoService.AddTagAsync(id, userId, tag);
        return NoContent();
    }

    [HttpDelete("{id}/tags")]
    public async Task<IActionResult> RemoveTag(string id, [FromQuery] string tag)
    {
        var userId = "test-user";
        await toDoService.RemoveTagAsync(id, userId);
        return NoContent();
    }
    
    [HttpPatch("{id}/deadline")]
    public async Task<IActionResult> SetDeadline(string id, [FromQuery] DateTime? deadline)
    {
        var userId = "test-user";
        await toDoService.SetDeadlineAsync(id, userId, deadline);
        return NoContent();
    }
}