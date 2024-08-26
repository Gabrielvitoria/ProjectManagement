using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectTaskHistoryService
    {
        Task<IEnumerable<ProjectTaskHistoryDto>> GetHistoryByProjectTaskIdAsync(Guid taskIs);
        Task<ProjectTaskHistory> CreateProjectTaskHistoryAsync(ProjectTaskHistory projectTaskHistory);
    }
}
