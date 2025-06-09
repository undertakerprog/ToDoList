namespace TasksService.Application.UseCases.Commands;

public record SetDeadlineCommand(string Id, string UserId, DateTime? Deadline);