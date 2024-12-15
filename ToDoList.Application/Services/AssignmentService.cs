using AutoMapper;
using ToDoList.Application.DTOs.Assignment;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Interfaces.Repositories;

namespace ToDoList.Application.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;
    
    public AssignmentService(IUnitOfWork unitOfWork, IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }
    
    public async Task<AssignmentDto?> GetByIdAsync(Guid id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        return _mapper.Map<AssignmentDto?>(assignment);
    }
    
    public async Task<AssignmentDto> CreateAsync(AssignmentDto assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        _assignmentRepository.Create(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto>(assignment);
    }
    
    public async Task<AssignmentDto?> UpdateAsync(AssignmentDto assignmentDto)
    {
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        if (await _assignmentRepository.GetByIdAsync(assignmentDto.Id) is null)
        {
            return null;
        }
        
        _assignmentRepository.Update(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto?>(assignment);
    }

    public async Task<AssignmentDto?> DeleteAsync(Guid id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment is null)
        {
            return null;
        }
        
        _assignmentRepository.Delete(assignment);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentDto?>(assignment);
    }
}