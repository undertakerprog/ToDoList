using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;
using TasksService.Application.UseCases.Commands;
using TasksService.Application.UseCases.Interfaces;
using TasksService.Application.UseCases.Queries;

namespace TasksService.Application.UseCases;

public class ToDoService(ICommandHandler commandHandler, IQueryHandler queryHandler) : IToDoService
{
    public Task<List<ToDoItemDto>> GetAllAsync(string userId)
    {
        var query = new GetAllToDoItemsQuery(userId);
        return queryHandler.Handle(query);
    }

    public Task<ToDoItemDto> GetByIdAsync(string id, string userId)
    {
        var query = new GetToDoItemByIdQuery(id, userId);
        return queryHandler.Handle(query);
    }

    public async Task<ToDoItemDto> CreateAsync(ToDoItemCreateDto itemDto, string userId)
    {
        var command = new CreateToDoItemCommand(itemDto, userId);
        var id = await commandHandler.Handle(command);
        return new ToDoItemDto 
        { 
            Id = id, 
            Title = itemDto.Title, 
            Description = itemDto.Description, 
            IsCompleted = itemDto.IsCompleted, 
            CreatedAt = DateTime.UtcNow
        };
    }

    public Task UpdateAsync(string id, ToDoItemDto itemDto, string userId)
    {
        var command = new UpdateToDoItemCommand(id, itemDto, userId);
        return commandHandler.Handle(command);
    }

    public Task DeleteAsync(string id, string userId)
    {
        var command = new DeleteToDoItemCommand(id, userId);
        return commandHandler.Handle(command);
    }
}