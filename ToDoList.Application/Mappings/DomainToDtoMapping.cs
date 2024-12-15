using AutoMapper;
using ToDoList.Application.DTOs.Assignment;
using ToDoList.Application.DTOs.AssignmentList;
using ToDoList.Application.DTOs.User;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Assignment, AssignmentDto>().ReverseMap();
        CreateMap<AssignmentList, AssignmentListDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}