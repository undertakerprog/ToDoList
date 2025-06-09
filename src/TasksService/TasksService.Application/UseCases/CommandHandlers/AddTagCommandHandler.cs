using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class AddTagCommandHandler(IToDoRepository repository)
{
    public async Task Handle(AddTagCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");
        if (string.IsNullOrEmpty(command.Tag)) throw new ArgumentException("Tag is required");

        var item = await repository.GetByIdAsync(command.Id, command.UserId) ?? throw new InvalidOperationException("Task not found");
        item.Characteristics.Tags.Add(command.Tag);
        await repository.UpdateAsync(command.Id, item);
    }
}