using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectManagement.Infra
{
    public class DbContextConfigurer : IDesignTimeDbContextFactory<ProjectManagementContext>
    {
        public ProjectManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementContext>();

            optionsBuilder.UseMySql("server=172.18.0.2;uid=root;pwd=123456;database=ProjectManagerDb",
                      new MySqlServerVersion(new Version(8, 0, 28)),
                      mySqlOptions =>
                      {
                          mySqlOptions.MigrationsAssembly("ProjectManagement.Infra");
                      }
                      );           
           
            return new ProjectManagementContext(optionsBuilder.Options);
        }
    }
}
