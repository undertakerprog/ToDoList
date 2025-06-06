using TasksService.Application.DTOs;

namespace TasksService.Application.UseCases.Commands;

public record UpdateToDoItemCommand(string Id, ToDoItemDto ItemDto, string UserId);