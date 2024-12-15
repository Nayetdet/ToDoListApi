using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(ApplicationDbContext context)
        : base(context)
    { }
}