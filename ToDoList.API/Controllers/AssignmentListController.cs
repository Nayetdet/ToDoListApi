using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.ViewModels.AssignmentList;
using ToDoList.Application.DTOs.AssignmentList;
using ToDoList.Application.Interfaces;

namespace ToDoList.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AssignmentListController : ControllerBase
{
    private readonly IAssignmentListService _assignmentListService;

    public AssignmentListController(IAssignmentListService assignmentListService)
    {
        _assignmentListService = assignmentListService;
    }

    [HttpGet("{id:guid}", Name = "get-assignment-list")]
    public async Task<ActionResult<AssignmentListDto>> GetByIdAsync(Guid id)
    {
        var assignmentListDto = await _assignmentListService.GetByIdAsync(id);
        if (assignmentListDto is null)
        {
            return NotFound("Assignment list not found");
        }
        
        return assignmentListDto;
    }

    [HttpPost]
    public async Task<ActionResult<AssignmentListDto>> CreateAsync([FromBody] CreateAssignmentListViewModel createAssignmentListViewModel)
    {
        var assignmentListDto = createAssignmentListViewModel.ToDto();
        var createdAssignmentListDto = await _assignmentListService.CreateAsync(assignmentListDto);
        return new CreatedAtRouteResult("get-assignment-list", new { id = createdAssignmentListDto.Id }, createdAssignmentListDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<AssignmentListDto>> UpdateAsync(Guid id, [FromBody] UpdateAssignmentListViewModel updateAssignmentListViewModel)
    {
        if (id != updateAssignmentListViewModel.Id)
        {
            return BadRequest("Id mismatch");
        }
        
        var assignmentListDto = updateAssignmentListViewModel.ToDto();
        var updatedAssignmentListDto = await _assignmentListService.UpdateAsync(assignmentListDto);
        if (updatedAssignmentListDto is null)
        {
            return NotFound("Assignment list not found");
        }
        
        return updatedAssignmentListDto;
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<AssignmentListDto>> DeleteAsync(Guid id)
    {
        var assignmentListDto = await _assignmentListService.DeleteAsync(id);
        if (assignmentListDto is null)
        {
            return NotFound("Assignment list not found");
        }
        
        return assignmentListDto;
    }
}