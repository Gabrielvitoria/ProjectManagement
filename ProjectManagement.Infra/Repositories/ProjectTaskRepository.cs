using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private ProjectManagementContext _context;
        public ProjectTaskRepository(ProjectManagementContext context)
        {
            _context = context;
        }

        public async Task<ProjectTask> CreateAsync(ProjectTask projectTask, CancellationToken cancellationToken = default)
        {
            await _context.ProjectTask.AddAsync(projectTask, cancellationToken);

            return projectTask;
        }

        public async Task<int> CreateAsync(List<ProjectTask> tasks, CancellationToken cancellationToken = default)
        {
            foreach (var item in tasks)
            {
                _context.ProjectTask.Add(item);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(ProjectTask task)
        {
            _context.ProjectTask.Remove(task);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProjectTask> GetByIdAsync(Guid id)
        {
            return await _context.ProjectTask.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<ProjectTask>> GetByProjectIdAsync(Guid id)
        {
            return await _context.ProjectTask.Where(x => x.ProjectId.Equals(id)).ToListAsync();
        }

        public async Task<ProjectTask> UpdateAsync(ProjectTask projectTask)
        {
            _context.ProjectTask.Update(projectTask);
            _context.SaveChanges();
            return projectTask;
        }
    }
}
