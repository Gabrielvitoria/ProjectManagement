using AutoMapper;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ReportService : IReportService
    {
        private readonly IProjectTaskHistoryRepository _projectTaskHistoryRepository;
        private readonly IMapper _mapper;

        public ReportService(IProjectTaskHistoryRepository projectTaskHistoryRepository, IMapper mapper)
        {
            _projectTaskHistoryRepository = projectTaskHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskPerformanceDto>> GetTaskPerformanceAsync()
        {
            try
            {
                return await _projectTaskHistoryRepository.GetTaskPerformanceAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
