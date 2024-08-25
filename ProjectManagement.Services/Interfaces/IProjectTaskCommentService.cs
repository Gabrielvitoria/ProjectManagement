using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProjectTaskCommentService
    {
        Task<ProjectTaskCommentDto> CreateAsync(CreateProjectTaskCommentDto createProjectTaskCommentDto);
    }
}
