using ToDoList.Application.DTOs.AssignmentList;

namespace ToDoList.Application.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDto?> GetByIdAsync(Guid id);
    Task<AssignmentListDto> CreateAsync(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto?> UpdateAsync(AssignmentListDto assignmentListDto);
    Task<AssignmentListDto?> DeleteAsync(Guid id);
}