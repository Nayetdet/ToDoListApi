using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> IsEmailAvailableAsync(string email);
}