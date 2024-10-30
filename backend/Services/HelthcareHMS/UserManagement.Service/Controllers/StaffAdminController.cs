using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Register([FromBody] RegisterStaffAdminDto request)
    {
        var staffAdmin = await _staffAdminService.RegisterStaffAdminAsync(request.Email, request.Login, request.Password, request.CreatedByGlobalAdminId);
        return CreatedAtAction(nameof(Register), new { id = staffAdmin.UserId }, staffAdmin);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _loginService.LoginStaffAdminAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }
}