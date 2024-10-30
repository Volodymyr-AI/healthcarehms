using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.DTOs;
using UserManagement.Service.Services.AuthServices;
using UserManagement.Service.Services.UserServices;

namespace UserManagement.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlobalAdminController : ControllerBase
    {
        private readonly GlobalAdminService _gaService;
        private readonly JwtAndLoginService _jwtAndLoginService;

        public GlobalAdminController(GlobalAdminService gaService, JwtAndLoginService jwtAndLoginService)
        {
            _gaService = gaService;
            _jwtAndLoginService = jwtAndLoginService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterGADto model)
        {
            var globalAdmin = await _gaService.RegisterGlobalAdminAsync(model.Email, model.Login, model.Password);
            return Ok(globalAdmin);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _jwtAndLoginService.LoginAsync(model.Email, model.Password);
            return Ok(new { Token = token });
        }
    }
}
