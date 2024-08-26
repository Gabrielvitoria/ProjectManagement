using AutoMapper;
using Newtonsoft.Json;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Infra.Repositories;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ProjectTaskCommentService : IProjectTaskCommentService
    {
        private readonly IProjectTaskHistoryRepository _projectTaskHistoryRepository;
        private readonly IProjectTaskCommentRepository _projectTaskCommentRepository;
        private readonly IMapper _mapper;


        public ProjectTaskCommentService(IProjectTaskHistoryRepository projectTaskHistoryRepository, IProjectTaskCommentRepository projectTaskCommentRepository, IMapper mapper)
        {
            _projectTaskHistoryRepository = projectTaskHistoryRepository;   
            _projectTaskCommentRepository = projectTaskCommentRepository;
            _mapper = mapper;
        }

        public async Task<ProjectTaskCommentDto> CreateAsync(CreateProjectTaskCommentDto createProjectTaskCommentDto)
        {
            try
            {
                var projectTaskComment = new ProjectTaskComment(createProjectTaskCommentDto.ProjectTaskId, createProjectTaskCommentDto.UserId, createProjectTaskCommentDto.Description);

                await _projectTaskCommentRepository.CreateAsync(projectTaskComment);

                var history = new ProjectTaskHistory(createProjectTaskCommentDto.ProjectTaskId, createProjectTaskCommentDto.UserId, "CreateComment", null, JsonConvert.SerializeObject(projectTaskComment));

                await _projectTaskHistoryRepository.CreateAsync(history);

                return _mapper.Map<ProjectTaskCommentDto>(projectTaskComment);
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
    }
}
