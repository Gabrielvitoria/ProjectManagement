using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Infra.Interfaces
{
    public interface IUserRepository
    {
        UserDto Get(string username, string password);
    }
}
