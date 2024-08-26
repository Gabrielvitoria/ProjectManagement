using AutoMapper;
using Moq;
using ProjectManagement.Common.AlterDto;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Services
{
    public class ProjectTaskServiceTest
    {
        [Fact]
        public async void AlterStatusWithExAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();


            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () => await service.AlterStatusAsync(new AlterStatusProjectTaskDto()));
        }

        [Fact]
        public async void AlterStatusWithAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            projectTaskRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Domain.Entities.ProjectTask(Guid.NewGuid(), "Teste", "Teste", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.Medium)));

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            var result = await service.AlterStatusAsync(new AlterStatusProjectTaskDto());

            Assert.NotNull(result);
        }

        [Fact]
        public async void AlterWithExAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () => await service.AlterAsync(new AlterProjectTaskDto()));
        }

        [Fact]
        public async void AlterAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            projectTaskRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Domain.Entities.ProjectTask(Guid.NewGuid(), "Teste", "Teste", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.Medium)));

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            var result = await service.AlterAsync(new AlterProjectTaskDto());
            Assert.NotNull(result);
        }

        [Fact]
        public async void CreateWithExAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();           

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () => await service.CreateAsync(new CreateProjectTaskDto()));
        }

        [Fact]
        public async void CreateAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            projectServiceMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Domain.Entities.Project("Teste", Guid.NewGuid())));

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            var result = await service.CreateAsync(new CreateProjectTaskDto());
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetProjectTaskByProjectIdAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            IEnumerable<ProjectTask> projectTaskList = new List<Domain.Entities.ProjectTask>();
            
            projectTaskRepositoryMoq.Setup(x => x.GetByProjectIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(projectTaskList));

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            var result = await service.GetProjectTaskByProjectIdAsync(Guid.NewGuid());
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteWithExAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () => await service.DeleteAsync(Guid.NewGuid()));
            
        }

        [Fact]
        public async void DeleteAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var projectTaskRepositoryMoq = new Mock<IProjectTaskRepository>();
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectServiceMoq = new Mock<IProjectService>();
            projectTaskRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Domain.Entities.ProjectTask(Guid.NewGuid(), "Teste", "Teste", DateTime.Now, Guid.NewGuid(), Domain.TaskPriorityEnum.Medium)));

            var service = new ProjectTaskService(projectTaskRepositoryMoq.Object, projectServiceMoq.Object, mapper, projectTaskHistoryRepositoryMoq.Object);
            await service.DeleteAsync(Guid.NewGuid());

            Assert.True(true);

        }
    }
}
