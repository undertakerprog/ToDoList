using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class DeleteToDoItemCommandHandler(IToDoRepository repository)
{
    public async Task Handle(DeleteToDoItemCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        await repository.DeleteAsync(command.Id, command.UserId);
    }
}