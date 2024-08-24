using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }


        [HttpGet(Name = "GetByProjectId")]
        public async Task<IActionResult> GetAllByUserIdAsync(Guid projectId)
        {
            try
            {
                return Ok(await _projectTaskService.GetProjectTaskByProjectIdAsync(projectId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
