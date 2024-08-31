using Microsoft.AspNetCore.Identity;
using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Infrastructure;

public static class InfrastructureDependenciesRegistration
{
    public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AppDbContext>
            (options => options.UseSqlServer(cfg.GetConnectionString("SchoolDBConnectionString")));
        services.AddIdentityCore<User>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+\r\n\r\n";
            options.User.RequireUniqueEmail = true;
            
            //options.SignIn.RequireConfirmedEmail = false;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
