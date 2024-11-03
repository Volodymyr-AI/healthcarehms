using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.Domain;
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterStaffMemberDto request)
    {
        var staffMember = await _staffMemberService.RegisterStaffMemberAsync(request.Email, request.Login, request.Password, request.CreatedById);
        return CreatedAtAction(nameof(Register), new { id = staffMember.UserId }, staffMember);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _loginService.LoginStaffMemberAsync(request.Email, request.Password);
        return Ok(new { Token = token });
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<StaffMember>>> GetAll()
    {
        return await _staffMemberService.GetAllStaffMembersAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var staffMember = await _staffMemberService.GetStaffMemberByIdAsync(id);
        if (staffMember == null)
            return NotFound("Staff Member not found");

        return Ok(staffMember);
    }
    
    [HttpPut("{id}/update-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateEmail(Guid id, [FromBody] string newEmail)
    {
        var result = await _staffMemberService.UpdateStaffMemberEmailAsync(id, newEmail);
        if (!result)
            return NotFound("Staff Member not found");

        return Ok("Email updated successfully");
    }
    
    [HttpPut("{id}/update-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePassword(Guid id, [FromBody] string newPassword)
    {
        var result = await _staffMemberService.UpdateStaffMemberPasswordAsync(id, newPassword);
        if (!result)
            return NotFound("Staff Member not found");

        return Ok("Password updated successfully");
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _staffMemberService.DeleteStaffMemberAsync(id);
        if (!result)
            return NotFound("Staff Member not found");

        return Ok("Staff Member deleted successfully");
    }
}