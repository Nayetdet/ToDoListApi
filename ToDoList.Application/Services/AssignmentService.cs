using AutoMapper;
using ToDoList.Application.DTOs.Assignment;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public AssignmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<AssignmentDto?> GetByIdAsync(Guid id)
    {
        var assignment = await _unitOfWork.AssignmentRepository.GetByIdAsync(id);
        return _mapper.Map<AssignmentDto?>(assignment);
    }
    
    public async Task<AssignmentDto> CreateAsync(AssignmentDto assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        _unitOfWork.AssignmentRepository.Create(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto>(assignment);
    }
    
    public async Task<AssignmentDto?> UpdateAsync(AssignmentDto assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        if (await _unitOfWork.AssignmentRepository.GetByIdAsync(assignmentDto.Id) is null)
        {
            return null;
        }
        
        _unitOfWork.AssignmentRepository.Update(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto?>(assignment);
    }

    public async Task<AssignmentDto?> DeleteAsync(Guid id)
    {
        var assignment = await _unitOfWork.AssignmentRepository.GetByIdAsync(id);
        if (assignment is null)
        {
            return null;
        }
        
        _unitOfWork.AssignmentRepository.Delete(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto?>(assignment);
    }
}