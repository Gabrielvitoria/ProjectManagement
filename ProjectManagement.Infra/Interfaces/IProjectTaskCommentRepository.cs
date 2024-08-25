using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IProjectTaskCommentRepository
    {
        Task<ProjectTaskComment> CreateAsync(ProjectTaskComment projectTaskComment);

    }
}
