using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SchoolApp.Application.Services.AuthenticationService;
using SchoolApp.Application.Services.RoleService;
using SchoolApp.Application.Services.UserService;

namespace SchoolApp.Application;

public static class ApplicationDependenciesRegistration
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration cfg)
    {
        // Configuration for MediaR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Configuration for Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // Configuration for FluentValidator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Configuration for Services
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthorizationService, AuthorizationService>();

        // Configuration for Authentication Services
        services.AddTransient<IAuthenticationService, AuthenticationService>();


        //JWT Authentication
        services.Configure<JwtSettings>(cfg.GetSection("JwtSettings"));
        var JwtSettings = new JwtSettings();
        cfg.GetSection(nameof(JwtSettings)).Bind(JwtSettings);
        services.AddSingleton(JwtSettings);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = JwtSettings.ValidateIssuer,
                ValidIssuers = new[] { JwtSettings.Issuer },

                ValidateAudience = JwtSettings.ValidateAudience,
                ValidAudience = JwtSettings.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddSwaggerGen(g =>
        {
            g.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
            g.EnableAnnotations();

            g.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer schema (e.g. Bearer 212555dfef)",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
            });

            g.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme // Should match the scheme name
                        },
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header
                    },
                    new List<string>() // This is a list of scopes, which is empty in this case
                }
            });
        });

        return services;
    }
}
