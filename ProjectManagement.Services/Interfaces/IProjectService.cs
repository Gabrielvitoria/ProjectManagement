using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId);
        Task<ProjectDto> CreateAsync(ProjectDto product);
        Task<ProjectDto> UpdateAsync(ProjectDto product);
    }
}
