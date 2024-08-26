using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProjectTaskCommentRepository : IProjectTaskCommentRepository
    {
        private ProjectManagementContext _context;

        public ProjectTaskCommentRepository(ProjectManagementContext context)
        {
            _context = context;
        }
        public async Task<ProjectTaskComment> CreateAsync(ProjectTaskComment projectTaskComment)
        {
            _context.ProjectTaskComment.Add(projectTaskComment);
            _context.SaveChanges();
            return projectTaskComment;
        }
    }
}
