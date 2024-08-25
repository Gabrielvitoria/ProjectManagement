using AutoMapper;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public  class ProjectService : IProjectService
    {
        private readonly IProjectRepository _productRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto newProjectDto)
        {
            var project = _mapper.Map<Domain.Entities.Project>(newProjectDto);
            var resultNewProject = await _productRepository.CreateAsync(project);
            return _mapper.Map<ProjectDto>(resultNewProject);
        }

        public async Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId)
        {
          var projects = await _productRepository.GetAllByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<Domain.Entities.Project> GetById(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public Task<ProjectDto> UpdateAsync(ProjectDto product)
        {
            throw new NotImplementedException();
        }
    }
}
