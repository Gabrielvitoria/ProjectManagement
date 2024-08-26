using AutoMapper;
using Moq;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services;
using ProjectManagement.Services.Project;

namespace ProjectManagement.Tests.Services
{
    public class ProjectTaskHistoryServiceTest
    {
        [Fact]
        public async void CreateProjectTaskHistoryAsync()
        {
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            var service = new ProjectTaskHistoryService(projectTaskHistoryRepositoryMoq.Object, mapper);
            var result = await service.CreateProjectTaskHistoryAsync(new Domain.Entities.ProjectTaskHistory(Guid.NewGuid(), Guid.NewGuid(), "Create", "Old", "New"));
            Assert.NotNull(result);
            Assert.True(result.Id != Guid.Empty);
        }

        [Fact]
        public async void GetHistoryByProjectTaskIdAsync()
        {
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            IEnumerable<ProjectTaskHistory> list = new List<ProjectTaskHistory>();

            projectTaskHistoryRepositoryMoq.Setup(x=> x.GetAllByProjectTaskIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(list));

            var service = new ProjectTaskHistoryService(projectTaskHistoryRepositoryMoq.Object, mapper);
            var result = await service.GetHistoryByProjectTaskIdAsync(Guid.NewGuid());
            Assert.NotNull(result);
        }
    }
}
