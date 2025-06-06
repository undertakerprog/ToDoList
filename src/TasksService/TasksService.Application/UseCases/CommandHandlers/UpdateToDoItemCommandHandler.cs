using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Entities;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class UpdateToDoItemCommandHandler(IToDoRepository repository)
{
    public async Task Handle(UpdateToDoItemCommand command)
    {
        ArgumentNullException.ThrowIfNull(command.ItemDto);
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        var existingItem = await repository.GetByIdAsync(command.Id, command.UserId);
        if (existingItem == null)
        {
            throw new InvalidOperationException("Task not found");
        }

        await repository.DeleteAsync(command.Id, command.UserId);

        var item = new ToDoItem
        {
            Id = command.Id,
            Title = command.ItemDto.Title,
            Description = command.ItemDto.Description,
            IsCompleted = command.ItemDto.IsCompleted,
            CreatedAt = existingItem.CreatedAt,
            UserId = command.UserId
        };

        await repository.UpdateAsync(command.Id, item);
    }
}