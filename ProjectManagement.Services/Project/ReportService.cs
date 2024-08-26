using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public class ReportService : IReportService
    {
        private readonly IProjectTaskHistoryRepository _projectTaskHistoryRepository;

        public ReportService(IProjectTaskHistoryRepository projectTaskHistoryRepository)
        {
            _projectTaskHistoryRepository = projectTaskHistoryRepository;
        }

        public async Task<IEnumerable<TaskPerformanceDto>> GetTaskPerformanceAsync()
        {

            return await _projectTaskHistoryRepository.GetTaskPerformanceAsync();
        }
    }
}
