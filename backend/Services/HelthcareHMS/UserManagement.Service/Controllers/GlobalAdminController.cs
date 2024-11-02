using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.Domain;
using UserManagement.Service.DTOs;
using UserManagement.Service.Services.AuthServices;
using UserManagement.Service.Services.UserServices;

namespace UserManagement.Service.Controllers
{
    [ApiController]
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] RegisterGADto model)
        {
            var globalAdmin = await _gaService.RegisterGlobalAdminAsync(model.Email, model.Login, model.Password);
            return Ok(globalAdmin);
        }

        
        [HttpPost("login")]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _jwtAndLoginService.LoginAsync(model.Email, model.Password);
            return Ok(new { Token = token });
        }
        
        
        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var globalAdmin = await _gaService.GetGlobalAdminByIdAsync(id);
            if (globalAdmin == null)
                return NotFound("Global Admin not found");

            return Ok(globalAdmin);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GlobalAdmin>>> GetAll()
        {
            return await _gaService.GetAllGlobalAdmin();
        }

        [HttpPut("{id}/update-email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEmail(Guid id, [FromBody] string newEmail)
        {
            var result = await _gaService.UpdateGlobalAdminEmailAsync(id, newEmail);
            if (!result)
                return NotFound("Global Admin not found");

            return Ok("Email updated successfully");
        }


        [HttpPut("{id}/update-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] string newPassword)
        {
            var result = await _gaService.UpdateGlobalAdminPasswordAsync(id, newPassword);
            if (!result)
                return NotFound("Global Admin not found");

            return Ok("Password updated successfully");
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _gaService.DeleteGlobalAdminAsync(id);
            if (!result)
                return NotFound("Global Admin not found");

            return Ok("Global Admin deleted successfully");
        }
    }
}
