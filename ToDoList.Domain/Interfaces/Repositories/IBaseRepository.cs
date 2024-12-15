using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}