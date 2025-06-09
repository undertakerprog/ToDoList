namespace TasksService.Domain.Entities;

public class ToDoItem
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }   
    public required string Description { get; set; } 
    public bool IsCompleted { get; set; } 
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public TaskCharacteristics Characteristics { get; init; } = new TaskCharacteristics();
    public required string UserId { get; init; } 
}