using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ProjectTaskDto>> GetProjectTaskByProjectIdAsync(Guid projectId);
    }
}
