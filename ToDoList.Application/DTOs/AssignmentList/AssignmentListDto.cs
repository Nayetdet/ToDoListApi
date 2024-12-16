using ToDoList.Application.DTOs.Assignment;

namespace ToDoList.Application.DTOs.AssignmentList;

public class AssignmentListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid UserId { get; set; }
    public List<AssignmentDto> Assignments { get; set; } = null!;
}
