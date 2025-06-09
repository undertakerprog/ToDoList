using TasksService.Application.UseCases.Commands;

namespace TasksService.Application.UseCases.Interfaces;

public interface ICommandHandler
{
    Task<string> Handle(CreateToDoItemCommand command);
    Task Handle(UpdateToDoItemCommand command);
    Task Handle(DeleteToDoItemCommand command);
    Task Handle(MarkAsCompletedCommand command);
    Task Handle(MarkAsIncompleteCommand command);
    Task Handle(ArchiveTaskCommand command);
    Task Handle(RestoreTaskCommand command);
    Task Handle(SetPriorityCommand command);
    Task Handle(AddTagCommand command);
    Task Handle(RemoveTagCommand command);
    Task Handle(SetDeadlineCommand command);
}