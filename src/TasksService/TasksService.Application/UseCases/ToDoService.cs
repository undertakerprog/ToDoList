using FluentValidation;
using TasksService.Application.DTOs;
using TasksService.Application.Interfaces;
using TasksService.Application.UseCases.Commands;
using TasksService.Application.UseCases.Interfaces;
using TasksService.Application.UseCases.Queries;

namespace TasksService.Application.UseCases;

public class ToDoService(ICommandHandler commandHandler, 
    IQueryHandler queryHandler, 
    IValidator<ToDoItemCreateDto> createDtoValidator) : IToDoService
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
        var validationResult = await createDtoValidator.ValidateAsync(itemDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors); 

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
    
    public Task MarkAsCompletedAsync(string id, string userId)
    {
        var command = new MarkAsCompletedCommand(id, userId);
        return commandHandler.Handle(command);
    }

    public Task MarkAsIncompleteAsync(string id, string userId)
    {
        var command = new MarkAsIncompleteCommand(id, userId);
        return commandHandler.Handle(command);
    }
    
    public Task ArchiveTaskAsync(string id, string userId)
    {
        var command = new ArchiveTaskCommand(id, userId);
        return commandHandler.Handle(command);
    }

    public Task RestoreTaskAsync(string id, string userId)
    {
        var command = new RestoreTaskCommand(id, userId);
        return commandHandler.Handle(command);
    }

    public Task SetPriorityAsync(string id, string userId, int priority)
    {
        var command = new SetPriorityCommand(id, userId, priority);
        return commandHandler.Handle(command);
    }

    public Task AddTagAsync(string id, string userId, string tag)
    {
        var command = new AddTagCommand(id, userId, tag);
        return commandHandler.Handle(command);
    }
    
    public Task RemoveTagAsync(string id, string userId)
    {
        var command = new RemoveTagCommand(id, userId);
        return commandHandler.Handle(command);
    }

    public Task SetDeadlineAsync(string id, string userId, DateTime? deadline)
    {
        var command = new SetDeadlineCommand(id, userId, deadline);
        return commandHandler.Handle(command);
    }
}