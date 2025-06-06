using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;
using TasksService.Domain.Entities;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.Services;

public class ToDoServiceImpl(IToDoRepository repository) : IToDoService
{
    public async Task<List<ToDoItemDto>> GetAllAsync(string userId)
    {
        var items = await repository.GetAllAsync(userId);
        return items.Select(MapToDto).ToList();
    }

    public async Task<ToDoItemDto> GetByIdAsync(string id, string userId)
    {
        var item = await repository.GetByIdAsync(id, userId);
        return (item != null ? MapToDto(item) : null)!;
    }

    public async Task<ToDoItemDto> CreateAsync(ToDoItemDto itemDto, string userId)
    {
        ArgumentNullException.ThrowIfNull(itemDto);
        if (string.IsNullOrEmpty(userId)) throw new ArgumentException("UserId is required");

        var item = new ToDoItem
        {
            Title = itemDto.Title,
            Description = itemDto.Description,
            IsCompleted = itemDto.IsCompleted,
            UserId = userId
        };
        var createdItem = await repository.CreateAsync(item);
        return MapToDto(createdItem);
    }
    
    public async Task UpdateAsync(string id, ToDoItemDto itemDto, string userId)
    {
        ArgumentNullException.ThrowIfNull(itemDto);
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(userId)) throw new ArgumentException("UserId is required");

        var existingItem = await repository.GetByIdAsync(id, userId);
        if (existingItem == null)
        {
            throw new InvalidOperationException("Task not found");
        }
        
        await repository.DeleteAsync(id, userId);

        var item = new ToDoItem
        {
            Id = id,
            Title = itemDto.Title,
            Description = itemDto.Description,
            IsCompleted = itemDto.IsCompleted,
            CreatedAt = existingItem.CreatedAt,
            UserId = userId
        };

        await repository.UpdateAsync(id, item);
    }

    public async Task DeleteAsync(string id, string userId)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(userId)) throw new ArgumentException("UserId is required");

        await repository.DeleteAsync(id, userId);
    }

    private static ToDoItemDto MapToDto(ToDoItem item)
    {
        return new ToDoItemDto
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            IsCompleted = item.IsCompleted,
            CreatedAt = item.CreatedAt
        };
    }
}