using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet(Name = "GetByUserId")]
        public async Task<IActionResult> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                return Ok(await _projectService.GetAllByUserIdAsync(userId));
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
                return Ok(await _projectService.CreateAsync(project));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> PostDeleteAsync(Guid projectId)
        {
            try
            {
                await _projectService.DeleteAsync(projectId);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
             
    }
}
