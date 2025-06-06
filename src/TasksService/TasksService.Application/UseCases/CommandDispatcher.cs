using TasksService.Application.UseCases.CommandHandlers;
using TasksService.Application.UseCases.Commands;
using TasksService.Application.UseCases.Interfaces;

namespace TasksService.Application.UseCases;

public class CommandDispatcher(
    CreateToDoItemCommandHandler createHandler,
    UpdateToDoItemCommandHandler updateHandler,
    DeleteToDoItemCommandHandler deleteHandler)
    : ICommandHandler
{
    public Task<string> Handle(CreateToDoItemCommand command) => createHandler.Handle(command);
    public Task Handle(UpdateToDoItemCommand command) => updateHandler.Handle(command);
    public Task Handle(DeleteToDoItemCommand command) => deleteHandler.Handle(command);
}