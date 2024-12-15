using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.ViewModels.Assignment;
using ToDoList.Application.DTOs.Assignment;
using ToDoList.Application.Interfaces;

namespace ToDoList.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet("{id:guid}", Name = "get-assignment")]
    public async Task<ActionResult<AssignmentDto>> GetByIdAsync(Guid id)
    {
        var assignmentDto = await _assignmentService.GetByIdAsync(id);
        if (assignmentDto is null)
        {
            return NotFound("Assignment not found");
        }
        
        return assignmentDto;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] CreateAssignmentViewModel createAssignmentViewModel)
    {
        var assignmentDto = createAssignmentViewModel.ToDto();
        var createdAssignment = await _assignmentService.CreateAsync(assignmentDto);
        return new CreatedAtRouteResult("get-assignment", new { createdAssignment.Id }, createdAssignment);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<AssignmentDto>> UpdateAsync(Guid id, [FromBody] UpdateAssignmentViewModel updateAssignmentViewModel)
    {
        if (id != updateAssignmentViewModel.Id)
        {
            return BadRequest("Id mismatch");
        }
        
        var assignmentDto = updateAssignmentViewModel.ToDto();
        var updatedAssignmentDto = await _assignmentService.UpdateAsync(assignmentDto);
        if (updatedAssignmentDto is null)
        {
            return NotFound("Assignment not found");
        }
        
        return updatedAssignmentDto;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<AssignmentDto>> DeleteAsync(Guid id)
    {
        var deletedAssignmentDto = await _assignmentService.DeleteAsync(id);
        if (deletedAssignmentDto is null)
        {
            return NotFound("Assignment not found");
        }
        
        return deletedAssignmentDto;
    }
}