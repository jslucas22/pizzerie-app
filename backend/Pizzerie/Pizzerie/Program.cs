using Pizzerie.Business.Services;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Business.Services.Authentication;
using Pizzerie.Business.Strategies;
using Pizzerie.Business.Strategies.Abstractions;
using Pizzerie.Data.DbConfig;
using Pizzerie.Data.Repositories;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.EmployeeCheckPad;
using Pizzerie.Domain.Models.User;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetValue<string>("ConnectionStrings:connection");

UserAuthenticationSettings.JwtSecret = builder.Configuration.GetValue<string>("AuthSetttings:Secret");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();

// Dependency Injection
builder.Services.AddSingleton<IDatabaseConnectionFactory>(new DatabaseConnectionFactory(conn));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeCheckPadService, EmployeeCheckPadService>();
builder.Services.AddScoped<IEmployeeCheckPadRepository, EmployeeCheckPadRepository>();
builder.Services.AddScoped<IValidationStrategy<EmployeeCheckPadCreateRequest>, EmployeeCheckPadCreateValidation>();
builder.Services.AddScoped<IValidationStrategy<EmployeeCheckPadEditRequest>, EmployeeCheckPadEditValidation>();
builder.Services.AddSingleton<IPasswordHasherService, PasswordHasherService>();

var app = builder.Build();

app.UseCors("EnableCORS");

app.UseAuthentication();

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();