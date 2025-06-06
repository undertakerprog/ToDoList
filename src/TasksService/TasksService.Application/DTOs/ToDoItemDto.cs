namespace TasksService.Application.DTOs;

public class ToDoItemDto
{
    public string? Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public bool IsCompleted { get; init; }
    public DateTime CreatedAt { get; set; }
}