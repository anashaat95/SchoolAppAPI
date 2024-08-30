using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Application.Core;
using SchoolApp.Application.Service;
using SchoolApp.Infrastructure;

namespace SchoolApp.DependencyInjectionConfigurationProject
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterProjectsDependencies(this IServiceCollection services, IConfiguration cfg)
        {
            services
                .RegisterInfrastructureDependencies(cfg)
                .RegisterApplicationCoreDependencies()
                .RegisterApplicationServiceDependencies();
            return services;
        }
    }
}
