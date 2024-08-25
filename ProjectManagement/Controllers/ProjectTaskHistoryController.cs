using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskHistoryController : ControllerBase
    {
        private readonly IProjectTaskHistoryService _projectTaskHistoryService;

        public ProjectTaskHistoryController(IProjectTaskHistoryService projectTaskHistoryService)
        {
            _projectTaskHistoryService = projectTaskHistoryService;                
        }

        [HttpGet(Name = "GetByProjectTaskId")]
        public async Task<IActionResult> GetByProjectTaskIdAsync(Guid taskId)
        {
            try
            {
                return Ok(await _projectTaskHistoryService.GetHistoryByProjectTaskIdAsync(taskId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
