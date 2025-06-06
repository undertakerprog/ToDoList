using TasksService.Application.DTOs;
using TasksService.Application.Helper;
using TasksService.Application.UseCases.Queries;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.QueryHandlers;

public class GetToDoItemByIdQueryHandler(IToDoRepository repository)
{
    public async Task<ToDoItemDto> Handle(GetToDoItemByIdQuery query)
    {
        var item = await repository.GetByIdAsync(query.Id, query.UserId);
        return (item != null ? DtoMapper.MapToDto(item) : null)!;
    }
}