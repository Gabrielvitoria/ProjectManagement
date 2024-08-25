using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.AlterDto;
using ProjectManagement.Common.CreateDto;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProjectTaskDto createProjectTaskDto)
        {
            try
            {
                return Ok(await _projectTaskService.CreateAsync(createProjectTaskDto));
            }
            catch(ApplicationException ex)
            {
              return  NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [Route("AlterStatus")]
        [HttpPatch]
        public async Task<IActionResult> PatchAsync(AlterStatusProjectTaskDto alterStatusProjectTaskDto)
        {
            try
            {
                return Ok(await _projectTaskService.AlterStatusAsync(alterStatusProjectTaskDto));
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
        
        [HttpPut]
        public async Task<IActionResult> PutAsync(AlterProjectTaskDto alterProjectTaskDto)
        {
            try
            {
                return Ok(await _projectTaskService.AlterAsync(alterProjectTaskDto));
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


        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> PostDeleteAsync(Guid projectTaskId)
        {
            try
            {
                await _projectTaskService.DeleteAsync(projectTaskId);
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
