using TasksService.Application.DTOs;
using TasksService.Domain.Entities;

namespace TasksService.Application.Helper;

public static class DtoMapper
{
    public static ToDoItemDto MapToDto(ToDoItem item)
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