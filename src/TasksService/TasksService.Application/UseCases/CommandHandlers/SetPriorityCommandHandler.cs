using FluentValidation;
using TasksService.Application.DTOs;
using TasksService.Application.UseCases.Commands;
using TasksService.Domain.Interfaces;

namespace TasksService.Application.UseCases.CommandHandlers;

public class SetPriorityCommandHandler(IToDoRepository repository, IValidator<TaskCharacteristicsDto> validator)
{
    public async Task Handle(SetPriorityCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) throw new ArgumentException("Id is required");
        if (string.IsNullOrEmpty(command.UserId)) throw new ArgumentException("UserId is required");

        var characteristics = new TaskCharacteristicsDto { Priority = command.Priority };
        var validationResult = await validator.ValidateAsync(characteristics);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var item = await repository.GetByIdAsync(command.Id, command.UserId) ?? throw new InvalidOperationException("Task not found");
        item.Characteristics.Priority = command.Priority;
        await repository.UpdateAsync(command.Id, item);
    }
}