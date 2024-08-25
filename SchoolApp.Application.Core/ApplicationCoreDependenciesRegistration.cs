using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolApp.Application.Core;

public static class ApplicationCoreDependenciesRegistration
{
    public static IServiceCollection RegisterApplicationCoreDependencies(this IServiceCollection services)
    {
        // Configuration for MediaR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Configuration for Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
