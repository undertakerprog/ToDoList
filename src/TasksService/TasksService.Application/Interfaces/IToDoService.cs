using TasksService.Application.DTOs;

namespace TasksService.Application.Interfaces;

public interface IToDoService
{
    Task<List<ToDoItemDto>> GetAllAsync(string userId);
    Task<ToDoItemDto> GetByIdAsync(string id, string userId);
    Task<ToDoItemDto> CreateAsync(ToDoItemCreateDto item, string userId); 
    Task UpdateAsync(string id, ToDoItemDto item, string userId);
    Task DeleteAsync(string id, string userId);
    Task MarkAsCompletedAsync(string id, string userId);
    Task MarkAsIncompleteAsync(string id, string userId);
    Task ArchiveTaskAsync(string id, string userId);
    Task RestoreTaskAsync(string id, string userId);
    Task SetPriorityAsync(string id, string userId, int priority);
    Task AddTagAsync(string id, string userId, string tag);
    Task RemoveTagAsync(string id, string userId);
    Task SetDeadlineAsync(string id, string userId, DateTime? deadline);
}