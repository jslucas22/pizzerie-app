using Pizzerie.Business.Services;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Business.Strategies;
using Pizzerie.Business.Strategies.Abstractions;
using Pizzerie.Data.DbConfig;
using Pizzerie.Data.Repositories;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.EmployeeCheckPad;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetValue<string>("ConnectionStrings:connection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDatabaseConnectionFactory>(new DatabaseConnectionFactory(conn));
builder.Services.AddScoped<IEmployeeCheckPadService, EmployeeCheckPadService>();
builder.Services.AddScoped<IEmployeeCheckPadRepository, EmployeeCheckPadRepository>();
builder.Services.AddScoped<IValidationStrategy<EmployeeCheckPadCreateRequest>, EmployeeCheckPadCreateValidation>();
builder.Services.AddScoped<IValidationStrategy<EmployeeCheckPadEditRequest>, EmployeeCheckPadEditValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
