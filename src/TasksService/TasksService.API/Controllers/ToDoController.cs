using Microsoft.AspNetCore.Mvc;
using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;

namespace TasksService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController(IToDoService toDoService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = "test-user";
        var items = await toDoService.GetAllAsync(userId);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var userId = "test-user";
        var item = await toDoService.GetByIdAsync(id, userId);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ToDoItemCreateDto item)
    {
        var userId = "test-user";
        var createdItem = await toDoService.CreateAsync(item, userId);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] ToDoItemDto item)
    {
        var userId = "test-user";
        await toDoService.UpdateAsync(id, item, userId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var userId = "test-user";
        await toDoService.DeleteAsync(id, userId);
        return NoContent();
    }
}