namespace TasksService.Application.DTOs;

public class ToDoItemCreateDto
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public bool IsCompleted { get; init; }
}