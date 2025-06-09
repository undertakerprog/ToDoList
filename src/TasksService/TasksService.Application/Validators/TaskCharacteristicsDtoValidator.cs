using FluentValidation;
using TasksService.Application.DTOs;

namespace TasksService.Application.Validators;

public class TaskCharacteristicsDtoValidator : AbstractValidator<TaskCharacteristicsDto>
{
    public TaskCharacteristicsDtoValidator()
    {
        RuleFor(x => x.Priority)
            .InclusiveBetween(0, 5).WithMessage("Priority must be between 0 and 5.");
        RuleForEach(x => x.Tags)
            .MaximumLength(50).WithMessage("Tag must not exceed 50 characters.");
        RuleFor(x => x.Deadline)
            .GreaterThanOrEqualTo(DateTime.UtcNow).When(x => x.Deadline.HasValue)
            .WithMessage("Deadline must be in the future.");
    }
}