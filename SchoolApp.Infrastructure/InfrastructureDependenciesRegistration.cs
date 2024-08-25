using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Domain.RepositoriesInterfaces;
using SchoolApp.Domain.RepositoriesInterfaces.Bases;
using SchoolApp.Infrastructure.Data.Contexts;
using SchoolApp.Infrastructure.Data.Repositories;
using SchoolApp.Infrastructure.Data.Repositories.Bases;

namespace SchoolApp.Infrastructure;

public static class InfrastructureDependenciesRegistration
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AppDbContext>
            (options=>options.UseSqlServer(cfg.GetConnectionString("SchoolDBConnectionString")));
        services.AddTransient<IStudentRepositoryAsync, StudentRepositoryAsync>();
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        return services;
    }
}
