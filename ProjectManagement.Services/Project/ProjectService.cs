using AutoMapper;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public  class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto newProjectDto)
        {
            var project = _mapper.Map<Domain.Entities.Project>(newProjectDto);
            var resultNewProject = await _projectRepository.CreateAsync(project);
            return _mapper.Map<ProjectDto>(resultNewProject);
        }

        public async Task DeleteAsync(Guid projectId)
        {
            try
            {
                var project = await _projectRepository.GetByIdForDeleteAsync(projectId);

                if (project == null)
                {
                    throw new ApplicationException($"Error: There are tasks pending completion. Update tasks or remove what is needed");
                }

                await _projectRepository.DeleteAsync(project);
            }
            catch(ApplicationException aex)
            {
                throw aex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId)
        {
          var projects = await _projectRepository.GetAllByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<Domain.Entities.Project> GetById(Guid id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }      
    }
}
