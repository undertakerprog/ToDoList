using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;

namespace TasksService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]  
public class ToDoController(IToDoService toDoService, IJwtUserService jwtUserService) : ControllerBase
{
    private readonly string _userId = jwtUserService.GetUserId();
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await toDoService.GetAllAsync(_userId);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await toDoService.GetByIdAsync(id, _userId);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ToDoItemCreateDto item)
    {
        var createdItem = await toDoService.CreateAsync(item, _userId);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] ToDoItemDto item)
    {
        await toDoService.UpdateAsync(id, item, _userId);
        return NoContent();
    }
    
    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> MarkAsCompleted(string id)
    {
        await toDoService.MarkAsCompletedAsync(id, _userId);
        return NoContent();
    }

    [HttpPatch("{id}/incomplete")]
    public async Task<IActionResult> MarkAsIncomplete(string id)
    {
        await toDoService.MarkAsIncompleteAsync(id, _userId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await toDoService.DeleteAsync(id, _userId);
        return NoContent();
    }
}