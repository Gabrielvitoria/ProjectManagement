using AutoMapper;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Infra.Interfaces;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services.Project
{
    public  class ProjectService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public Task<ProjectDto> CreateAsync(ProjectDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(Guid userId)
        {
          var projects = await _productRepository.GetAllByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public Task<ProjectDto> UpdateAsync(ProjectDto product)
        {
            throw new NotImplementedException();
        }
    }
}
