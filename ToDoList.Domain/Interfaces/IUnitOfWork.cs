using ToDoList.Domain.Interfaces.Repositories;

namespace ToDoList.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IAssignmentRepository AssignmentRepository { get; }
    IAssignmentListRepository AssignmentListRepository { get; }
    Task CommitAsync();
}