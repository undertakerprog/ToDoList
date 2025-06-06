namespace TasksService.Application.UseCases.Commands;

public record DeleteToDoItemCommand(string Id, string UserId);