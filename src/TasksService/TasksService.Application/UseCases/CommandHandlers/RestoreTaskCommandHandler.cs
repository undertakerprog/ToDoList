using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class RestoreTaskCommandHandler(IToDoRepository repository)
{
    public async Task Handle(RestoreTaskCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        var item = await repository.GetByIdAsync(command.Id, command.UserId) ?? throw new InvalidOperationException("Task not found");
        item.Characteristics.IsArchived = false;
        await repository.UpdateAsync(command.Id, item);
    }
}