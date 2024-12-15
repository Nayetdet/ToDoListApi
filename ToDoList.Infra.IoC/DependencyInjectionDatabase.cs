using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.IoC;

public static class DependencyInjectionDatabase
{
    public static IServiceCollection AddInfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            );
        });

        return services;
    }
}