namespace TasksService.Application.UseCases.Commands;

public record RestoreTaskCommand(string Id, string UserId);