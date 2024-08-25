using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid id);
        Task<Project> GetByIdAsync(Guid id);
        Task<Project> CreateAsync(Project product);
        Task<Project> UpdateAsync(Project product);
        Task<Project> DeleteAsync(Guid id);
    }
}
