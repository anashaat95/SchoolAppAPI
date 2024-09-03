namespace SchoolApp.Infrastructrue;

public static class InfrastructrueDependenciesRegistration
{
    public static IServiceCollection RegisterInfrastructrueDependencies(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<AppDbContext>
            (options => options.UseSqlServer(cfg.GetConnectionString("SchoolDBConnectionString")));

        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
        })
            .AddUserManager<UserManager<User>>()
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }
}
