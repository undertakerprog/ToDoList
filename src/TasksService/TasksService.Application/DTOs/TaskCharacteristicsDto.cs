namespace TasksService.Application.DTOs;

public class TaskCharacteristicsDto
{
    public bool IsArchived { get; init; }
    public int Priority { get; init; }
    public HashSet<string> Tags { get; init; } = [];
    public DateTime? Deadline { get; init; }
}