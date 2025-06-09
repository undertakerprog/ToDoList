namespace TasksService.Application.UseCases.Commands;

public record ArchiveTaskCommand(string Id, string UserId);