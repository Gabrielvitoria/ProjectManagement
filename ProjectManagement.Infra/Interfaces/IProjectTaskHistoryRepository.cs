using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectTaskHistoryRepository
    {
        Task<IEnumerable<ProjectTaskHistory>> GetAllAsync();
        Task<ProjectTaskHistory> GetByIdAsync(Guid id);
        Task<ProjectTaskHistory> CreateAsync(ProjectTaskHistory history);
        Task<ProjectTaskHistory> UpdateAsync(ProjectTaskHistory history);
        Task<ProjectTaskHistory> DeleteAsync(ProjectTaskHistory history); 
    }
}
