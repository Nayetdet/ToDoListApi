using ToDoList.Application.DTOs.AssignmentList;

namespace ToDoList.Application.DTOs.Assignment;

public class AssignmentDto
{
    public Guid Id { get; set; }
    public string Description { get; set; } = null!;
    public Guid UserId { get; set; }
    public Guid? AssignmentListId { get; set; }
    public bool Concluded { get; set; }
    public DateTime? ConcludedAt { get; set; }
    public DateTime? Deadline { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public AssignmentListDto AssignmentList { get; set; } = null!;
}