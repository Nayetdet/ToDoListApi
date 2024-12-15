using FluentValidation;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Domain.Validators;

public abstract class BaseValidator<T> : AbstractValidator<T> where T : BaseEntity
{
    public void EnsureValidation(T entity)
    {
        var validation = Validate(entity);
        if (!validation.IsValid)
        {
            var errorMessages = string.Join(";", validation.Errors.Select(x => x.ErrorMessage));
            throw new DomainValidationException($"Validation failed for {typeof(T).Name}: {errorMessages}");
        }
    }
}