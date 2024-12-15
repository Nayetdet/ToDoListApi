using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> IsEmailAvailableAsync(string email)
    {
        return await GetByEmailAsync(email) is null;
    }
}