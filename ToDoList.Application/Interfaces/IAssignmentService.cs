using ToDoList.Application.DTOs.Assignment;

namespace ToDoList.Application.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDto?> GetByIdAsync(Guid id);
    Task<AssignmentDto> CreateAsync(AssignmentDto assignmentDto);
    Task<AssignmentDto?> UpdateAsync(AssignmentDto assignmentDto);
    Task<AssignmentDto?> DeleteAsync(Guid id);
}