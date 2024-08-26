using SchoolApp.API.MiddleWares;
using SchoolApp.DependencyInjectionConfigurationProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DependenciesRegistration
builder.Services
    .RegisterProjectsDependencies(builder.Configuration);
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middlewares
app.UseMiddleware<ErrorHandlerMiddleware>();
#endregion
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
