using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectManagementContext _context;
        public ProjectRepository(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _context.Project.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;

        }

        public async Task DeleteAsync(Project project, CancellationToken cancellationToken = default(CancellationToken))
        {
            _context.Project.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid id)
        {
            return await _context.Project.Where(x => x.UserId.Equals(id)).ToListAsync();
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _context.Project.Include(i => i.ProjectTask).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Project> GetByIdForDeleteAsync(Guid id)
        {
            return await _context.Project.Include(i => i.ProjectTask)
                                         .FirstOrDefaultAsync(x => x.Id.Equals(id) &&
                                                                  !x.ProjectTask.Any() ||
                                                                   x.ProjectTask.All(t => t.Status.Equals(TaskStatusEnum.Completed)));

        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _context.Project.Update(project);
            _context.SaveChanges();
            return project;
        }
    }
}
