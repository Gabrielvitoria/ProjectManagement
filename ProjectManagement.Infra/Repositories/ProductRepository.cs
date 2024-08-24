using Microsoft.EntityFrameworkCore;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infra.Interfaces;

namespace ProjectManagement.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private ProjectManagementContext _context;
        public ProductRepository(ProjectManagementContext context)
        {
            _context = context;
        }

        public Task<Project> CreateAsync(Project product)
        {
            throw new NotImplementedException();
        }

        public Task<Project> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllByUserIdAsync(Guid id)
        {
           return await _context.Project.Where(x => x.UserId.Equals(id)).ToListAsync();
        }

        public Task<Project> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(Project product)
        {
            throw new NotImplementedException();
        }
    }
}
