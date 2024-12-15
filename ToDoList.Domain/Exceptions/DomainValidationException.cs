namespace ToDoList.Domain.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string error)
        : base(error)
    { }
}