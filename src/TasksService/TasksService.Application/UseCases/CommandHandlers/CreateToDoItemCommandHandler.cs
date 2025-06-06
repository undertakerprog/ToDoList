using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Entities;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class CreateToDoItemCommandHandler(IToDoRepository repository)
{
    public async Task<string> Handle(CreateToDoItemCommand command)
    {
        ArgumentNullException.ThrowIfNull(command.ItemDto);
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        var item = new ToDoItem
        {
            Title = command.ItemDto.Title,
            Description = command.ItemDto.Description,
            IsCompleted = command.ItemDto.IsCompleted,
            UserId = command.UserId,
            CreatedAt = DateTime.UtcNow
        };
        var createdItem = await repository.CreateAsync(item);
        return createdItem.Id;
    }
}