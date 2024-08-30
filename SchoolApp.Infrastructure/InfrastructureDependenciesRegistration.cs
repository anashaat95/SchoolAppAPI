namespace SchoolApp.Infrastructure;

public static class InfrastructureDependenciesRegistration
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AppDbContext>
            (options => options.UseSqlServer(cfg.GetConnectionString("SchoolDBConnectionString")));
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
