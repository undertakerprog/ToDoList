using TasksService.Application.DTOs;
using TasksService.Application.UseCases.Queries;

namespace TasksService.Application.UseCases.Interfaces;

public interface IQueryHandler
{
    Task<List<ToDoItemDto>> Handle(GetAllToDoItemsQuery query);
    Task<ToDoItemDto> Handle(GetToDoItemByIdQuery query);
}