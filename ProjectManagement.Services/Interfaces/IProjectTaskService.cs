using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ProjectTaskDto>> GetProjectTaskByProjectIdAsync(Guid projectId);
        Task<ProjectTaskDto> CreateAsync(CreateProjectTaskDto createProjectTaskDto);
    }
}
