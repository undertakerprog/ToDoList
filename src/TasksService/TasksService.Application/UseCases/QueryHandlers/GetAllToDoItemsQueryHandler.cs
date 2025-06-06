using TasksService.Application.DTOs;
using TasksService.Application.Helper;
using TasksService.Application.UseCases.Queries;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.QueryHandlers;

public class GetAllToDoItemsQueryHandler(IToDoRepository repository)
{
    public async Task<List<ToDoItemDto>> Handle(GetAllToDoItemsQuery query)
    {
        var items = await repository.GetAllAsync(query.UserId);
        return items.Select(DtoMapper.MapToDto).ToList();
    }
}