using AutoMapper;
using Moq;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services;
using ProjectManagement.Services.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Services
{
    public class ProjectTaskCommentServiceTest
    {
        [Fact]
        public async void Create()
        {
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectTaskCommentRepositoryMoq = new Mock<IProjectTaskCommentRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var service = new ProjectTaskCommentService(projectTaskHistoryRepositoryMoq.Object, projectTaskCommentRepositoryMoq.Object, mapper);
          
            var result = await service.CreateAsync(new Common.CreateDto.CreateProjectTaskCommentDto
            {
                UserId = Guid.NewGuid(),
                ProjectTaskId = Guid.NewGuid(),
                Description = "Comentário"
            });
            
            Assert.NotNull(result);
            Assert.Equal("Comentário", result.Description);
        }

        [Fact]
        public async void CreateWithEx()
        {
            var projectTaskHistoryRepositoryMoq = new Mock<IProjectTaskHistoryRepository>();
            var projectTaskCommentRepositoryMoq = new Mock<IProjectTaskCommentRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            var mapper = config.CreateMapper();
            var service = new ProjectTaskCommentService(null, projectTaskCommentRepositoryMoq.Object, mapper);
            
            await Assert.ThrowsAsync<NullReferenceException>(async () =>  await service.CreateAsync(new Common.CreateDto.CreateProjectTaskCommentDto()));
        }
    }
}
