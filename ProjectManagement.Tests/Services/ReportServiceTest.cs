using Moq;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Project;
using System.Net.WebSockets;

namespace ProjectManagement.Tests.Services
{
    public class ReportServiceTest
    {
        [Fact]
        public async void GetTaskPerformanceAsync()
        {
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            IEnumerable<TaskPerformanceDto> taskPerformanceDtos = new List<TaskPerformanceDto>();
            projectTaskHistoryRepositoryMoq.Setup(x => x.GetTaskPerformanceAsync()).Returns(Task.FromResult(taskPerformanceDtos));

            var service = new ReportService(projectTaskHistoryRepositoryMoq.Object);
            var result = await service.GetTaskPerformanceAsync();
            Assert.NotNull(result);
        }
    }
}
