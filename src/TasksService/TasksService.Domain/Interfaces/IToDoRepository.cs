using TasksService.Domain.Entities;

namespace TasksService.Domain.Interfaces;

public interface IToDoRepository
{
    Task<List<ToDoItem>> GetAllAsync(string userId);
    Task<ToDoItem?> GetByIdAsync(string id, string userId);
    Task<ToDoItem> CreateAsync(ToDoItem item);
    Task UpdateAsync(string id, ToDoItem item);
    Task DeleteAsync(string id, string userId);
}