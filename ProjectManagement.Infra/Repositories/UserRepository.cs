using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserDto Get(string username, string password)
        {
            var users = new List<UserDto>();
            users.Add(new UserDto { Id = Guid.NewGuid(), Username = "master", Password = "master", Role = "gerente" });
            users.Add(new UserDto { Id = Guid.NewGuid(), Username = "basic", Password = "basic", Role = "usuario" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
