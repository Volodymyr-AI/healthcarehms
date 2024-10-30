using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.DTOs;
using UserManagement.Service.Services.AuthServices;
using UserManagement.Service.Services.UserServices;

namespace UserManagement.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaffMemberController : ControllerBase
{
    private readonly StaffMemberService _staffMemberService;
    private readonly JwtAndLoginService _loginService;

    public StaffMemberController(StaffMemberService staffMemberService, JwtAndLoginService loginService)
    {
        _staffMemberService = staffMemberService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterStaffMemberDto request)
    {
        var staffMember = await _staffMemberService.RegisterStaffMemberAsync(request.Email, request.Login, request.Password, request.CreatedById);
        return CreatedAtAction(nameof(Register), new { id = staffMember.UserId }, staffMember);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _loginService.LoginStaffMemberAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }
}