using TasksService.Application.UseCases.Commands;

namespace TasksService.Application.UseCases.Interfaces;

public interface ICommandHandler
{
    Task<string> Handle(CreateToDoItemCommand command);
    Task Handle(UpdateToDoItemCommand command);
    Task Handle(DeleteToDoItemCommand command);
}