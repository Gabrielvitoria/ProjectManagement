using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProductRepository : IProjectRepository
    {

        private ProjectManagementContext _context;
        public ProductRepository(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;

        }

        public Task<Project> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid id)
        {
            return await _context.Project.Where(x => x.UserId.Equals(id)).ToListAsync();
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _context.Project.Include(i => i.ProjectTask).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _context.Project.Update(project);
            _context.SaveChanges();
            return project;
        }
    }
}
