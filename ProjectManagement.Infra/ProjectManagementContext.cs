using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions options) : base(options)
        {
        }

        protected ProjectManagementContext()
        {
        }

        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectTask> ProjectTask { get; set; }
        public virtual DbSet<ProjectTaskHistory> ProjectTaskHistory { get; set; }
        public virtual DbSet<ProjectTaskComment> ProjectTaskComment { get; set; }

     
    }
}
