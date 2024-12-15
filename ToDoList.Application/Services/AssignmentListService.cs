using AutoMapper;
using ToDoList.Application.DTOs.AssignmentList;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Interfaces.Repositories;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IMapper _mapper;
    
    public AssignmentListService(IUnitOfWork unitOfWork, IAssignmentListRepository assignmentListRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _assignmentListRepository = assignmentListRepository;
        _mapper = mapper;
    }
    
    public async Task<AssignmentListDto?> GetByIdAsync(Guid id)
    {
        var assignmentList = await _assignmentListRepository.GetByIdAsync(id);
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }
    
    public async Task<AssignmentListDto> CreateAsync(AssignmentListDto assignmentListDto)
    {
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        _assignmentListRepository.Create(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto>(assignmentList);
    }
    
    public async Task<AssignmentListDto?> UpdateAsync(AssignmentListDto assignmentListDto)
    {
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        if (await _assignmentListRepository.GetByIdAsync(assignmentListDto.Id) is null)
        {
            return null;
        }
        
        _assignmentListRepository.Update(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }

    public async Task<AssignmentListDto?> DeleteAsync(Guid id)
    {
        var assignmentList = await _assignmentListRepository.GetByIdAsync(id);
        if (assignmentList is null)
        {
            return null;
        }
        
        _assignmentListRepository.Delete(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }
}