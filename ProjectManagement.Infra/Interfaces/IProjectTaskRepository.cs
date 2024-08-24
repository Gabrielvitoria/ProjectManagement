using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetByProjectIdAsync(Guid id);
        Task<ProjectTask> GetByIdAsync(Guid id);
        Task<ProjectTask> CreateAsync(ProjectTask projectTask, CancellationToken cancellationToken = default);
        Task<int> CreateAsync(List<ProjectTask> tasks, CancellationToken cancellationToken = default);
        Task<ProjectTask> UpdateAsync(ProjectTask task);
        Task<int> DeleteAsync(ProjectTask task);
    }
}
