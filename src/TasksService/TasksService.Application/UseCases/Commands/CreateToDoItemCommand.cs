using TasksService.Application.DTOs;

namespace TasksService.Application.UseCases.Commands;

public record CreateToDoItemCommand(ToDoItemCreateDto ItemDto, string UserId);