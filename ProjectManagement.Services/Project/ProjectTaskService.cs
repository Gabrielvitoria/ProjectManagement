using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, IMapper mapper)
        {
            _projectTaskRepository = projectTaskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectTaskDto>> GetProjectTaskByProjectIdAsync(Guid projectId)
        {
            try
            {
                var projectTasks = await _projectTaskRepository.GetByProjectIdAsync(projectId);

                return _mapper.Map<IEnumerable<ProjectTaskDto>>(projectTasks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
