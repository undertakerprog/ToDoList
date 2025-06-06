using TasksService.Application.DTOs;

namespace TasksService.Application.Interfaces;

public interface IToDoService
{
    Task<List<ToDoItemDto>> GetAllAsync(string userId);
    Task<ToDoItemDto> GetByIdAsync(string id, string userId);
    Task<ToDoItemDto> CreateAsync(ToDoItemDto item, string userId); 
    Task UpdateAsync(string id, ToDoItemDto item, string userId);
    Task DeleteAsync(string id, string userId);
}