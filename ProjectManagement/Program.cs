using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Common;
using ProjectManagement.Extension;
using ProjectManagement.Infra;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Infra.Repositories;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Project;
using System.Text;

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
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

builder.Services.AddTransient<IProjectTaskService, ProjectTaskService>();
builder.Services.AddTransient<IProjectTaskRepository, ProjectTaskRepository>();

builder.Services.AddTransient<IProjectTaskHistoryService, ProjectTaskHistoryService>();
builder.Services.AddTransient<IProjectTaskHistoryRepository, ProjectTaskHistoryRepository>();

builder.Services.AddTransient<IProjectTaskCommentService, ProjectTaskCommentService>();
builder.Services.AddTransient<IProjectTaskCommentRepository, ProjectTaskCommentRepository>();

builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProjectManagementContext>(options =>
     options.UseMySql(connectionString,
                      new MySqlServerVersion(new Version(8, 0, 28)),
                      mySqlOptions =>
                      {
                          mySqlOptions.MigrationsAssembly("ProjectManagement.Infra");
                      }
                      ));

//autenticacao-autorizacao
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Seguranca
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("gerente", policy => policy.RequireClaim("Project", "gerente"));
    
});

var app = builder.Build();

using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProjectManagementContext>();
    await dbContext.Database.EnsureCreatedAsync();
}


//app.CreateDbIfNotExists();

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
