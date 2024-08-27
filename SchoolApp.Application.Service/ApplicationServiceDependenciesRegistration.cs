namespace SchoolApp.Application.Service;

public static class ApplicationServiceDependenciesRegistration
{
    public static IServiceCollection RegisterApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        return services;
    }
}
