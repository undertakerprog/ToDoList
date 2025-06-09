    using FluentValidation;
    using TasksService.Application.DTOs;

    namespace TasksService.Application.Validators;

    public class ToDoItemCreateDtoValidator : AbstractValidator<ToDoItemCreateDto>
    {
        public ToDoItemCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.IsCompleted)
                .NotNull().WithMessage("IsCompleted must be specified.");
        }
    }