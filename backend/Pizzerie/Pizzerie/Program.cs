using Pizzerie.Business.Services;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Data.Repositories;
using Pizzerie.Data.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeCheckPadService, EmployeeCheckPadService>();
builder.Services.AddScoped<IEmployeeCheckPadRepository, EmployeeCheckPadRepository>();
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
