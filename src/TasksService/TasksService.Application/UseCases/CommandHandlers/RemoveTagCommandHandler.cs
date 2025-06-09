using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class RemoveTagCommandHandler(IToDoRepository repository)
{
    public async Task Handle(RemoveTagCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        var item = await repository.GetByIdAsync(command.Id, command.UserId) ?? throw new InvalidOperationException("Task not found");
        if (item.Characteristics.Tags.Count != 0)
        {
            var lastTag = item.Characteristics.Tags.Last();
            item.Characteristics.Tags.Remove(lastTag);
            await repository.UpdateAsync(command.Id, item);
        }
    }
}