using Microsoft.AspNetCore.Localization;
using SchoolApp.API.MiddleWares;
using SchoolApp.Infrastructure;
using SchoolApp.Application;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using SchoolApp.Domain.Entities.Identity;
using SchoolApp.Infrastructure.Data.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DependenciesRegistration
builder.Services
    .RegisterInfrastructureDependencies(builder.Configuration)
    .RegisterApplicationDependencies(builder.Configuration);
#endregion

#region Localization
builder.Services
    .AddLocalization(options => options.ResourcesPath = "");

// Configure supported cultures
var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("ar-EG")
};

builder.Services
    .Configure<RequestLocalizationOptions>(options =>
    {
        options.DefaultRequestCulture = new RequestCulture("en-US");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
        options.FallBackToParentCultures = false;
        options.FallBackToParentUICultures = false;
        options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider()); // Add QueryStringProvider for culture switching
    });
#endregion

#region AllowingCORS
var AllowAllCORS = "_AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllCORS,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});
#endregion



var app = builder.Build();

#region DataSeeding
using (var scope = app.Services.CreateScope())
{
    await RoleSeeder.SeedAsync(scope.ServiceProvider.GetRequiredService<RoleManager<Role>>());
    await UserSeeder.SeedAsync(scope.ServiceProvider.GetRequiredService<UserManager<User>>());
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Locatization
app.UseRequestLocalization();
#endregion

#region Middlewares
app.UseMiddleware<ErrorHandlerMiddleware>();
#endregion
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(AllowAllCORS);

app.Run();
