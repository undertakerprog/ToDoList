using TasksService.Application.UseCases.CommandHandlers;
using TasksService.Application.UseCases.Commands;
using TasksService.Application.UseCases.Interfaces;

namespace TasksService.Application.UseCases;

public class CommandDispatcher(
    CreateToDoItemCommandHandler createHandler,
    UpdateToDoItemCommandHandler updateHandler,
    DeleteToDoItemCommandHandler deleteHandler,
    MarkAsCompletedCommandHandler markAsCompletedHandler,
    MarkAsIncompleteCommandHandler markAsIncompleteHandler,
    ArchiveTaskCommandHandler archiveHandler,
    RestoreTaskCommandHandler restoreHandler,
    SetPriorityCommandHandler setPriorityHandler,
    AddTagCommandHandler addTagHandler,
    RemoveTagCommandHandler removeTagHandler,
    SetDeadlineCommandHandler setDeadlineHandler)
    : ICommandHandler
{
    public Task<string> Handle(CreateToDoItemCommand command) => createHandler.Handle(command);
    public Task Handle(UpdateToDoItemCommand command) => updateHandler.Handle(command);
    public Task Handle(DeleteToDoItemCommand command) => deleteHandler.Handle(command);
    public Task Handle(MarkAsCompletedCommand command) => markAsCompletedHandler.Handle(command);
    public Task Handle(MarkAsIncompleteCommand command) => markAsIncompleteHandler.Handle(command);
    public Task Handle(ArchiveTaskCommand command) => archiveHandler.Handle(command);
    public Task Handle(RestoreTaskCommand command) => restoreHandler.Handle(command);
    public Task Handle(SetPriorityCommand command) => setPriorityHandler.Handle(command);
    public Task Handle(AddTagCommand command) => addTagHandler.Handle(command);
    public Task Handle(RemoveTagCommand command) => removeTagHandler.Handle(command);
    public Task Handle(SetDeadlineCommand command) => setDeadlineHandler.Handle(command);
}