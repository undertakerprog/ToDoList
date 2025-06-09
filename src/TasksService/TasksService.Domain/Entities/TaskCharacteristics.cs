namespace TasksService.Domain.Entities;

public class TaskCharacteristics
{
    public bool IsArchived { get; set; } = false;
    public int Priority { get; set; } = 0;
    public HashSet<string> Tags { get; set; } = [];
    public DateTime? Deadline { get; set; }
}