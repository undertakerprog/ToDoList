using TasksService.Domain.Entities;
using TasksService.Domain.Interfaces;

namespace TasksService.Infrastructure.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly List<ToDoItem> _todoItems = [];

    public Task<List<ToDoItem>> GetAllAsync(string userId)
    {
        return Task.FromResult(_todoItems.Where(i => i.UserId == userId).ToList());
    }

    public Task<ToDoItem?> GetByIdAsync(string id, string userId)
    {
        return Task.FromResult(_todoItems.FirstOrDefault(i => i.Id == id && i.UserId == userId));
    }

    public Task<ToDoItem> CreateAsync(ToDoItem item)
    {
        _todoItems.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(string id, ToDoItem item)
    {
        _todoItems.Add(item);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id, string userId)
    {
        var item = _todoItems.FirstOrDefault(i => i.Id == id && i.UserId == userId);
        if (item != null)
        {
            _todoItems.Remove(item);
        }
        return Task.CompletedTask;
    }
}