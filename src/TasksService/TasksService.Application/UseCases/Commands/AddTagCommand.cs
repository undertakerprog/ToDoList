namespace TasksService.Application.UseCases.Commands;

public record AddTagCommand(string Id, string UserId, string Tag);