using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public sealed class AssignmentList : BaseEntity
{
    public string Name { get; private set; }
    public Guid UserId { get; private set; }
    
    // EF Relations
    public User User { get; private set; } = null!;
    public ICollection<Assignment> Assignments { get; private set; } = null!;

    public AssignmentList(string name, Guid userId)
    {
        Name = name;
        UserId = userId;
    }
    
    public void ChangeName(string name)
    {
        Name = name;
        Validate();
    }
    
    protected override void Validate()
    {
        var validator = new AssignmentListValidator();
        validator.EnsureValidation(this);
    }
}