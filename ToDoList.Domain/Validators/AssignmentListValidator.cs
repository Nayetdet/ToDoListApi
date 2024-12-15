using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators;

public class AssignmentListValidator : BaseValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
    }
}