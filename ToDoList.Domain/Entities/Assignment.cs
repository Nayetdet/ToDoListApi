using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public sealed class Assignment : BaseEntity
{
    public string Description { get; private set; }
    public Guid UserId { get; private set; }
    public Guid? AssignmentListId { get; private set; }
    public bool Concluded { get; private set; }
    public DateTime? ConcludedAt { get; private set; }
    public DateTime? Deadline { get; private set; }
    
    // EF Relations
    public User User { get; private set; } = null!;
    public AssignmentList AssignmentList { get; private set; } = null!;
    
    public Assignment(string description, Guid userId, Guid? assignmentListId, DateTime? deadline)
    {
        Description = description;
        UserId = userId;
        AssignmentListId = assignmentListId;
        Deadline = deadline;
    }
    
    public void ChangeDescription(string description)
    {
        Description = description;
        UpdateTimestamp();
        Validate();
    }

    public void Restart()
    {
        Concluded = false;
        ConcludedAt = null;
        UpdateTimestamp();
    }
    
    public void Finish()
    {
        Concluded = true;
        ConcludedAt = DateTime.Now;
        UpdateTimestamp();
    }

    protected override void Validate()
    {
        var validator = new AssignmentValidator();
        validator.EnsureValidation(this);
    }
}