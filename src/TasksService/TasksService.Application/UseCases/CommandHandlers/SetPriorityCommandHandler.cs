using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class SetPriorityCommandHandler(IToDoRepository repository)
{
    public async Task Handle(SetPriorityCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");
        if (command.Priority is < 0 or > 2) throw new ArgumentException("Priority must be between 0 and 2");

        var item = await repository.GetByIdAsync(command.Id, command.UserId) ?? throw new InvalidOperationException("Task not found");
        item.Characteristics.Priority = command.Priority;
        await repository.UpdateAsync(command.Id, item);
    }
}