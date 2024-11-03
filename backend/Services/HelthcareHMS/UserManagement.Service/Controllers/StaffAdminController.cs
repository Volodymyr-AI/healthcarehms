using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.Domain;
using UserManagement.Service.DTOs;
using UserManagement.Service.Services.AuthServices;
using UserManagement.Service.Services.UserServices;

namespace UserManagement.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffAdminController : ControllerBase
{
    private readonly StaffAdminService _staffAdminService;
    private readonly JwtAndLoginService _loginService;

    public StaffAdminController(StaffAdminService staffAdminService, JwtAndLoginService loginService)
    {
        _staffAdminService = staffAdminService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterStaffAdminDto request)
    {
        var staffAdmin = await _staffAdminService.RegisterStaffAdminAsync(request.Email, request.Login, request.Password, request.CreatedByGlobalAdminId);
        return CreatedAtAction(nameof(Register), new { id = staffAdmin.UserId }, staffAdmin);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _loginService.LoginStaffAdminAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StaffAdmin>>> GetAll()
    {
        return await _staffAdminService.GetAllStaffAdminsAsync();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var staffAdmin = await _staffAdminService.GetStaffAdminByIdAsync(id);
        if (staffAdmin == null)
            return NotFound("Staff Admin not found");

        return Ok(staffAdmin);
    }
    
    [HttpPut("{id}/update-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateEmail(Guid id, [FromBody] string newEmail)
    {
        var result = await _staffAdminService.UpdateStaffAdminEmailAsync(id, newEmail);
        if (!result)
            return NotFound("Staff Admin not found");

        return Ok("Email updated successfully");
    }
    
    [HttpPut("{id}/update-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] string newPassword)
    {
        var result = await _staffAdminService.UpdateStaffAdminPasswordAsync(id, newPassword);
        if (!result)
            return NotFound("Staff Admin not found");

        return Ok("Password updated successfully");
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _staffAdminService.DeleteStaffAdminAsync(id);
        if (!result)
            return NotFound("Staff Admin not found");

        return Ok("Staff Admin deleted successfully");
    }
}