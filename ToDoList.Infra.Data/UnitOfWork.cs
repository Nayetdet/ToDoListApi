using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data.Context;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    
    private IUserRepository? _userRepository;
    private IAssignmentRepository? _assignmentRepository;
    private IAssignmentListRepository? _assignmentListRepository;
    
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IAssignmentRepository AssignmentRepository => _assignmentRepository ??= new AssignmentRepository(_context);
    public IAssignmentListRepository AssignmentListRepository => _assignmentListRepository ??= new AssignmentListRepository(_context);
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}