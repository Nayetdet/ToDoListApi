using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext Context;
    
    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var entity = await Context.Set<T>().FindAsync(id);
        return entity;
    }

    public void Create(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
        entity.UpdateTimestamp();
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}