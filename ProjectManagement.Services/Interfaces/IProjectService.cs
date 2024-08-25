using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId);
        Task<Domain.Entities.Project> GetById(Guid id);
        Task<ProjectDto> CreateAsync(CreateProjectDto newProjectDto);
        Task DeleteAsync(Guid projectId);
    }
}
