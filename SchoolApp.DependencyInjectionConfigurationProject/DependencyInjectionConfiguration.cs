using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Application.Core;
using SchoolApp.Application.Service;
using SchoolApp.Infrastructure;
using System.ComponentModel.Design;

namespace SchoolApp.DependencyInjectionConfigurationProject
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterProjectsDependencies(this IServiceCollection services, IConfiguration cfg)
        {
            services
                .RegisterApplicationCoreDependencies()
                .RegisterApplicationServiceDependencies()
                .RegisterInfrastructureDependencies(cfg);
            return services;
        }
    }
}
