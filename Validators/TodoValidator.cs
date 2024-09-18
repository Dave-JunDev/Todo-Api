using DTO;
using FluentValidation;

namespace Validators;

public class TodoValidators : AbstractValidator<TodoDTO>
{
    public TodoValidators()
    {
        RuleFor(t => t.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .MaximumLength(50)
            .WithMessage("Title must not exceed 50 characters");

        RuleFor(t => t.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .MaximumLength(200)
            .WithMessage("Description must not exceed 200 characters");

        RuleFor(t => t.IsCompleted)
            .NotNull()
            .WithMessage("IsCompleted is required");
    }
}