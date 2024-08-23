using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infra;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DbContextConfigurer>();


var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ProjectManagementContext>(options =>
     options.UseMySql(connectionString,
                      new MySqlServerVersion(new Version(8, 0, 28)),
                      mySqlOptions =>
                      {
                          mySqlOptions.MigrationsAssembly("ProjectManagement.Infra");
                      }
                      ));


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
