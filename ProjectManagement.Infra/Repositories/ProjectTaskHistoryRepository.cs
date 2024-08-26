using Microsoft.EntityFrameworkCore;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain;
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
            return await _context.ProjectTaskHistory.AsNoTracking().Where(x => x.ProjectTaskId.Equals(projectTaskId)).ToListAsync();
        }

        public async Task<IEnumerable<TaskPerformanceDto>> GetTaskPerformanceAsync()
        {
            var dateInit = DateTime.Now.AddDays(-30).Date;
            var dateEnd = DateTime.Now.Date;

            var result = await _context.ProjectTaskHistory.Include(i => i.ProjectTask)
                                                          .Where(x => (x.ProjectTask.Status.Equals(TaskStatusEnum.Completed)) &&
                                                                      (x.Type.Equals("UpdateStatus")) &&
                                                                      (x.DateTime.Date >= dateInit && x.DateTime.Date <= dateEnd))
                                                          .GroupBy(x => x.UserId)
                                                          .Select(s => new TaskPerformanceDto { UserId = s.Key, Quantity = s.Count() })
                                                          .ToListAsync();
            return result;
        }
    }
}
