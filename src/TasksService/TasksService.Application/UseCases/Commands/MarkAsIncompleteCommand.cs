namespace TasksService.Application.UseCases.Commands;

public record MarkAsIncompleteCommand(string Id, string UserId);