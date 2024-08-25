using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProjectTaskHistoryRepository : IProjectTaskHistoryRepository
    {
        private readonly ProjectManagementContext _context;

        public ProjectTaskHistoryRepository(ProjectManagementContext projectManagementContext)
        {
            _context = projectManagementContext;
        }


        public async Task<ProjectTaskHistory> CreateAsync(ProjectTaskHistory history)
        {
            _context.ProjectTaskHistory.Add(history);
            _context.SaveChanges();
            return history;
        }

        public async Task<IEnumerable<ProjectTaskHistory>> GetAllByProjectTaskIdAsync(Guid projectTaskId)
        {
           return await _context.ProjectTaskHistory.Where(x => x.ProjectTaskId.Equals(projectTaskId)).ToListAsync();
        }
    }
}
