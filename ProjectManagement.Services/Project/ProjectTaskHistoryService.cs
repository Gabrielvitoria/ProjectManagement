using AutoMapper;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ProjectTaskHistoryService : IProjectTaskHistoryService
    {
        private readonly IProjectTaskHistoryRepository _projectTaskHistoryRepository;
        private readonly IMapper _mapper;

        public ProjectTaskHistoryService(IProjectTaskHistoryRepository projectTaskHistoryRepository, IMapper mapper)
        {
            _projectTaskHistoryRepository = projectTaskHistoryRepository;
            _mapper = mapper;
        }

        public async Task<ProjectTaskHistory> CreateProjectTaskHistoryAsync(ProjectTaskHistory projectTaskHistory)
        {
            await _projectTaskHistoryRepository.CreateAsync(projectTaskHistory);

            return projectTaskHistory;
        }

        public async Task<IEnumerable<ProjectTaskHistoryDto>> GetHistoryByProjectTaskIdAsync(Guid taskIs)
        {
            var history = await _projectTaskHistoryRepository.GetAllByProjectTaskIdAsync(taskIs);

            return _mapper.Map<IEnumerable<ProjectTaskHistoryDto>>(history);
        }
    }
}
