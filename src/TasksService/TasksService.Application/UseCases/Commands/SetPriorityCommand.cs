namespace TasksService.Application.UseCases.Commands;

public record SetPriorityCommand(string Id, string UserId, int Priority);