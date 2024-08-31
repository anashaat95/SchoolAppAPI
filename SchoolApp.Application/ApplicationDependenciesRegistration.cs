namespace SchoolApp.Application;

public static class ApplicationDependenciesRegistration
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        // Configuration for MediaR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Configuration for Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient<IStudentService, StudentService>();
        return services;
    }
}
