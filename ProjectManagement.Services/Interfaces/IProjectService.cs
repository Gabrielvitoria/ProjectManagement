using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId);
        Task<ProjectDto> CreateAsync(CreateProjectDto newProjectDto);
        Task<ProjectDto> UpdateAsync(ProjectDto product);
    }
}
