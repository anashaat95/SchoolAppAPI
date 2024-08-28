using Microsoft.AspNetCore.Localization;
using SchoolApp.API.MiddleWares;
using SchoolApp.DependencyInjectionConfigurationProject;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DependenciesRegistration
builder.Services
    .RegisterProjectsDependencies(builder.Configuration);
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


var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
