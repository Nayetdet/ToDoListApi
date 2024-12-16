using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToDoList.Application.DTOs.AssignmentList;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public AssignmentListService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<AssignmentListDto?> GetByIdAsync(Guid id)
    {
        var assignmentList = await _unitOfWork.AssignmentListRepository.GetByIdAsync(id);
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }
    
    public async Task<AssignmentListDto> CreateAsync(AssignmentListDto assignmentListDto)
    {
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        _unitOfWork.AssignmentListRepository.Create(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto>(assignmentList);
    }
    
    public async Task<AssignmentListDto?> UpdateAsync(AssignmentListDto assignmentListDto)
    {
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        if (await _unitOfWork.AssignmentListRepository.GetByIdAsync(assignmentListDto.Id) is null)
        {
            return null;
        }
        
        _unitOfWork.AssignmentListRepository.Update(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }

    public async Task<AssignmentListDto?> DeleteAsync(Guid id)
    {
        var assignmentList = await _unitOfWork.AssignmentListRepository.GetByIdAsync(id);
        if (assignmentList is null)
        {
            return null;
        }
        
        _unitOfWork.AssignmentListRepository.Delete(assignmentList);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<AssignmentListDto?>(assignmentList);
    }
}