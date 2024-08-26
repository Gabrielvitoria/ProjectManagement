using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Common.Dtos;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Services.Project;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticateController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserDto user)
        {
            try
            {
                var token = _tokenService.GenerateToken(user.UserName, user.Password);

                return Ok(new
                {
                    user = token.Item1,
                    token = token.Item2
                });
            }
            catch (ApplicationException aex)
            {
                return NotFound(aex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
