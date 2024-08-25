using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IProjectTaskHistoryRepository _projectTaskHistoryRepository;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, IProjectService projectService,  IMapper mapper, IProjectTaskHistoryRepository projectTaskHistoryRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectService = projectService;
            _mapper = mapper;
            _projectTaskHistoryRepository = projectTaskHistoryRepository;
        }

        public async Task<ProjectTaskDto> CreateAsync(CreateProjectTaskDto createProjectTaskDto)
        {
            try
            {
                var project = await _projectService.GetById(createProjectTaskDto.ProjectId);

                if (project == null)
                {
                    throw new ApplicationException($"Error: Project id Informed {createProjectTaskDto.ProjectId} don't exist");
                }

                var projectTask = _mapper.Map<ProjectTask>(createProjectTaskDto);

                project.AddTask(projectTask);

                var history = new ProjectTaskHistory(projectTask.Id, createProjectTaskDto.UserId, "Create", null, JsonConvert.SerializeObject(projectTask));

                await _projectTaskRepository.CreateAsync(projectTask);
                await _projectTaskHistoryRepository.CreateAsync(history);

                return _mapper.Map<ProjectTaskDto>(projectTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
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
