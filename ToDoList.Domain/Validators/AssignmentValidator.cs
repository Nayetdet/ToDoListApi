using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators;

public class AssignmentValidator : BaseValidator<Assignment>
{
    public AssignmentValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters");

        RuleFor(x => x.UserId)
            .NotNull().WithMessage("UserId is required");
    }
}