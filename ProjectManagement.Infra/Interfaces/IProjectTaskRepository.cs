using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetAllAsync();
        Task<ProjectTask> GetByIdAsync(Guid id);
        Task<ProjectTask> CreateAsync(ProjectTask task);
        Task<ProjectTask> CreateAsync(List<ProjectTask> tasks);
        Task<ProjectTask> UpdateAsync(ProjectTask task);
        Task<ProjectTask> DeleteAsync(ProjectTask task);
    }
}
