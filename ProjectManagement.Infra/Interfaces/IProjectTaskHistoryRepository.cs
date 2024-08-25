using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectTaskHistoryRepository
    {
        Task<IEnumerable<ProjectTaskHistory>> GetAllByProjectTaskIdAsync(Guid projectTaskId);
        
        Task<ProjectTaskHistory> CreateAsync(ProjectTaskHistory history);
        
    }
}
