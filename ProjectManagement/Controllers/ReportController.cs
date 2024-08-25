using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
                _reportService = reportService;
        }

        //[Authorize(Roles = "Gerente")]
        [Route("TaskPerformance")]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _reportService.GetTaskPerformanceAsync());
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
