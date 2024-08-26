using Moq;
using ProjectManagement.Common.AlterDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Tests.Services
{
    public class TokenServiceTest
    {
        [Fact]
        public async void GetToken()
        {
            var userRepositoryMoq = new Mock<IUserRepository>();
            userRepositoryMoq.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(new UserDto { Id = Guid.NewGuid(), Password = "master", Username = "master", Role = "gerente" });

            var service = new TokenService(userRepositoryMoq.Object);
            var result = service.GenerateToken("master", "master");
            Assert.Equal("master", result.Item1);
            Assert.NotNull(result.Item2);
        }

        [Fact]
        public async void GetTokenWithEx()
        {
            var userRepositoryMoq = new Mock<IUserRepository>();            
            var service = new TokenService(userRepositoryMoq.Object);
            
            await Assert.ThrowsAsync<ApplicationException>(async () => service.GenerateToken("master", "master"));
        }
    }
}
