namespace SchoolApp.Application.Core;

public static class ApplicationCoreDependenciesRegistration
{
    public static IServiceCollection RegisterApplicationCoreDependencies(this IServiceCollection services)
    {
        // Configuration for MediaR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Configuration for Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
