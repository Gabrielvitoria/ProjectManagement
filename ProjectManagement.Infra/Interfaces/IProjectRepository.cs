using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid id);
        Task<Project> GetByIdAsync(Guid id);
        Task<Project> GetByIdForDeleteAsync(Guid id);
        Task<Project> CreateAsync(Project project);
        Task<Project> UpdateAsync(Project project);
        Task DeleteAsync(Project project, CancellationToken cancellationToken = default(CancellationToken));
    }
}
