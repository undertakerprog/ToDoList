namespace TasksService.Application.UseCases.Commands;

public record MarkAsCompletedCommand(string Id, string UserId);