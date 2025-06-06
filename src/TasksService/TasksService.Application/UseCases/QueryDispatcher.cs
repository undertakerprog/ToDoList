using TasksService.Application.DTOs;
using TasksService.Application.UseCases.Queries;
using TasksService.Application.UseCases.QueryHandlers;
using TasksService.Application.UseCases.Interfaces;

namespace TasksService.Application.UseCases;

public class QueryDispatcher(
    GetAllToDoItemsQueryHandler getAllHandler,
    GetToDoItemByIdQueryHandler getByIdHandler)
    : IQueryHandler
{
    public Task<List<ToDoItemDto>> Handle(GetAllToDoItemsQuery query) => getAllHandler.Handle(query);
    public Task<ToDoItemDto> Handle(GetToDoItemByIdQuery query) => getByIdHandler.Handle(query);
}