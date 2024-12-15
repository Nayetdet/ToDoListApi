using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentListRepository : BaseRepository<AssignmentList>, IAssignmentListRepository
{
    public AssignmentListRepository(ApplicationDbContext context)
        : base(context)
    { }
}