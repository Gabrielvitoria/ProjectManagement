using ProjectManagement.Common.Dtos;

namespace ProjectManagement.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId);
        Task<ProjectDto> CreateAsync(ProjectDto product);
        Task<ProjectDto> UpdateAsync(ProjectDto product);
    }
}
