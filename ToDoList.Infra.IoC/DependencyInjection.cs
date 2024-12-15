using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Mappings;
using ToDoList.Application.Services;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Interfaces.Repositories;
using ToDoList.Infra.Data;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IAssignmentListRepository, AssignmentListRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddScoped<IAssignmentListService, AssignmentListService>();
        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddScoped<IAuthService, AuthService>();
        
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        
        return services;
    }
}