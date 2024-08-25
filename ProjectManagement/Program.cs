using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infra;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Infra.Repositories;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Project;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DbContextConfigurer>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


//Services and Reposytory
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IProjectRepository, ProductRepository>();

builder.Services.AddTransient<IProjectTaskService, ProjectTaskService>();
builder.Services.AddTransient<IProjectTaskRepository, ProjectTaskRepository>();

builder.Services.AddTransient<IProjectTaskHistoryService, ProjectTaskHistoryService>();
builder.Services.AddTransient<IProjectTaskHistoryRepository, ProjectTaskHistoryRepository>();






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
