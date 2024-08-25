using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _productService;

        public ProjectController(IProjectService productService)
        {
                _productService = productService;
        }


        [HttpGet(Name = "GetByUserId")]
        public async Task<IActionResult> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                return Ok(await _productService.GetAllByUserIdAsync(userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProjectDto project)
        {
            try
            {
                return Ok(await _productService.CreateAsync(project));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
