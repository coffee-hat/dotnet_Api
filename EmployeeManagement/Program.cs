using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connexion  la base de donnes
builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("EmployeesDatabase")));

// Ajout des repositories
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
// Ajout des services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();