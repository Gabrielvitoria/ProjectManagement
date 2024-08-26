using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<TaskPerformanceDto>> GetTaskPerformanceAsync();
    }
}
