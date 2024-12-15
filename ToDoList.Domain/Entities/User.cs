using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public sealed class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    // EF Relations
    public ICollection<Assignment> Assignments { get; private set; } = null!;
    public ICollection<AssignmentList> AssignmentLists { get; private set; } = null!;
    
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        Validate();
    }
    
    public void ChangeName(string name)
    {
        Name = name;
        UpdateTimestamp();
        Validate();
    }
    
    public void ChangeEmail(string email)
    {
        Email = email;
        UpdateTimestamp();
        Validate();
    }
    
    public void ChangePassword(string password)
    {
        Password = password;
        UpdateTimestamp();
        Validate();
    }

    protected override void Validate()
    {
        var validator = new UserValidator();
        validator.EnsureValidation(this);
    }
}