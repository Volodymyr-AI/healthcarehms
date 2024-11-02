using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffMS.WebAPI.Domain.UserRelated;
using StaffMS.WebAPI.Services;

namespace StaffMS.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GlobalAdminController : ControllerBase
{
    private readonly GlobalAdminService _globalAdminService;

    public GlobalAdminController(GlobalAdminService globalAdminService)
    {
        _globalAdminService = globalAdminService;
    }

    // Редагування полів GlobalAdmin
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGlobalAdmin(Guid id, [FromBody] GlobalAdminEntity updatedAdmin)
    {
        try
        {
            var admin = await _globalAdminService.UpdateGlobalAdminAsync(id, updatedAdmin);
            return Ok(admin);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("GlobalAdmin not found");
        }
    }

    // Створення департаменту
    [HttpPost("departments")]
    public async Task<ActionResult<DepartmentEntity>> CreateDepartment([FromBody] DepartmentEntity newDepartment)
    {
        var department = await _globalAdminService.CreateDepartmentAsync(newDepartment);
        return Ok(newDepartment);
    }

    // Отримання департаменту за ID
    //[HttpGet("departments/{id}")]
    //public async Task<IActionResult> GetDepartmentById(Guid id)
    //{
    //    var department = await _globalAdminService.GetDepartmentByIdAsync(id);
    //    if (department == null)
    //    {
    //        return NotFound("Department not found");
    //    }
    //    return Ok(department);
    //}

    // Редагування департаменту
    [HttpPut("departments/{id}")]
    public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentEntity updatedDepartment)
    {
        try
        {
            var department = await _globalAdminService.UpdateDepartmentAsync(id, updatedDepartment);
            return Ok(department);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Department not found");
        }
    }

    // Видалення департаменту
    [HttpDelete("departments/{id}")]
    public async Task<ActionResult> DeleteDepartment(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _globalAdminService.DeleteDepartmentAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Department not found");
        }
    }

    // Редагування StaffAdmin
    [HttpPut("staffadmins/{id}")]
    public async Task<IActionResult> UpdateStaffAdmin(Guid id, [FromBody] StaffAdminEntity updatedStaffAdmin, CancellationToken cancellationToken)
    {
        try
        {
            var staffAdmin = await _globalAdminService.UpdateStaffAdminAsync(id, updatedStaffAdmin, cancellationToken);
            return Ok(staffAdmin);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("StaffAdmin not found");
        }
    }

    // Видалення StaffAdmin
    [HttpDelete("staffadmins/{id}")]
    public async Task<IActionResult> DeleteStaffAdmin(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _globalAdminService.DeleteStaffAdminAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("StaffAdmin not found");
        }
    }

    // Редагування StaffMember
    [HttpPut("staffmembers/{id}")]
    public async Task<IActionResult> UpdateStaffMember(Guid id, [FromBody] StaffMemberEntity updatedStaffMember, CancellationToken cancellationToken)
    {
        try
        {
            var staffMember = await _globalAdminService.UpdateStaffMemberAsync(id, updatedStaffMember, cancellationToken);
            return Ok(staffMember);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("StaffMember not found");
        }
    }

    // Видалення StaffMember
    [HttpDelete("staffmembers/{id}")]
    public async Task<IActionResult> DeleteStaffMember(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _globalAdminService.DeleteStaffMemberAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("StaffMember not found");
        }
    }
}