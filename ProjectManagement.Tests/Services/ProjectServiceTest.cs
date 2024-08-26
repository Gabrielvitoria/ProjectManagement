using AutoMapper;
using Moq;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Project;
using Xunit.Sdk;

namespace ProjectManagement.Tests.Services
{
    public class ProjectServiceTest
    {
        [Fact]
        public async void CreateInstance()
        {
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var mapperMoq = new Mock<IMapper>();

            projectRepositoryMoq.Setup(x => x.GetByIdForDeleteAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Project()));
            projectRepositoryMoq.Setup(x => x.DeleteAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            var service = new ProjectService(projectRepositoryMoq.Object, mapperMoq.Object);

            await service.DeleteAsync(Guid.NewGuid());
            Assert.True(true);
        }


        [Fact]
        public async void Create()
        {
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();

            projectRepositoryMoq.Setup(x => x.CreateAsync(It.IsAny<Project>())).Returns(Task.FromResult(new Project("Novo", Guid.NewGuid())));

            var service = new ProjectService(projectRepositoryMoq.Object, mapper);
            var reult = await service.CreateAsync(new CreateProjectDto());
            Assert.NotNull(reult);
        }

        [Fact]
        public async void CreateWithApplicationException()
        {
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var mapperMoq = new Mock<IMapper>();

            projectRepositoryMoq.Setup(x => x.GetByIdForDeleteAsync(It.IsAny<Guid>()));
            projectRepositoryMoq.Setup(x => x.DeleteAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var service = new ProjectService(projectRepositoryMoq.Object, mapperMoq.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () => await service.DeleteAsync(Guid.NewGuid()));
        }

        [Fact]
        public async void GetAllByUserIdAsync()
        {
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var mapperMoq = new Mock<IMapper>();
            IEnumerable<Project> list = new List<Project>();
            projectRepositoryMoq.Setup(x => x.GetAllByUserIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(list));
            var service = new ProjectService(projectRepositoryMoq.Object, mapperMoq.Object);

            Assert.NotNull(service.GetAllByUserIdAsync(Guid.NewGuid()));
        }

        [Fact]
        public async void GetById()
        {
            var projectRepositoryMoq = new Mock<IProjectRepository>();
            var mapperMoq = new Mock<IMapper>();
            projectRepositoryMoq.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new Project()));
            var service = new ProjectService(projectRepositoryMoq.Object, mapperMoq.Object);

            Assert.NotNull(service.GetByIdAsync(Guid.NewGuid()));
        }
    }
}
