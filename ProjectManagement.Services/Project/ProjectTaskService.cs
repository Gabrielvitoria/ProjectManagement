using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProjectManagement.Common.AlterDto;
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

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, IProjectService projectService, IMapper mapper, IProjectTaskHistoryRepository projectTaskHistoryRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectService = projectService;
            _mapper = mapper;
            _projectTaskHistoryRepository = projectTaskHistoryRepository;
        }

        public async Task<ProjectTaskDto> AlterStatusAsync(AlterStatusProjectTaskDto alterStatusProjectTaskDto)
        {
            try
            {
                var projectTask = await _projectTaskRepository.GetByIdAsync(alterStatusProjectTaskDto.Id);

                if (projectTask == null)
                {
                    throw new ApplicationException($"Error: Task of Project id Informed {alterStatusProjectTaskDto.Id} don't exist");
                }

                var history = projectTask.SetStatus(alterStatusProjectTaskDto.Status, alterStatusProjectTaskDto.UserId);

                await _projectTaskHistoryRepository.CreateAsync(history);

                return _mapper.Map<ProjectTaskDto>(projectTask);
            }
            catch (ApplicationException aex)
            {
                throw aex;
            }
        }

        public async Task<ProjectTaskDto> AlterAsync(AlterProjectTaskDto alterProjectTaskDto)
        {
            try
            {
                var projectTask = await _projectTaskRepository.GetByIdAsync(alterProjectTaskDto.Id);

                if (projectTask == null)
                {
                    throw new ApplicationException($"Error: Task of Project id Informed {alterProjectTaskDto.Id} don't exist");
                }

                var history = projectTask.Alter(alterProjectTaskDto.UserId, alterProjectTaskDto.Title, alterProjectTaskDto.Description, alterProjectTaskDto.DueDate);

                await _projectTaskHistoryRepository.CreateAsync(history);

                return _mapper.Map<ProjectTaskDto>(projectTask);
            }
            catch (ApplicationException aex)
            {
                throw aex;
            }
        }

        public async Task<ProjectTaskDto> CreateAsync(CreateProjectTaskDto createProjectTaskDto)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(createProjectTaskDto.ProjectId);

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

            var projectTasks = await _projectTaskRepository.GetByProjectIdAsync(projectId);

            return _mapper.Map<IEnumerable<ProjectTaskDto>>(projectTasks);

        }

        public async Task DeleteAsync(Guid projectTaskId)
        {
            try
            {
                var projectTask = await _projectTaskRepository.GetByIdAsync(projectTaskId);

                if (projectTask == null)
                {
                    throw new ApplicationException($"Error: Task of Project id Informed {projectTaskId} don't exist");
                }

                await _projectTaskRepository.DeleteAsync(projectTask);
            }
            catch (ApplicationException aex)
            {
                throw aex;
            }
        }
    }
}
