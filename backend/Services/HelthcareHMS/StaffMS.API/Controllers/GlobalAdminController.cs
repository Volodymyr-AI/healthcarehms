using AutoMapper;
using StaffMS.Application.Utils.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;
using StaffMS.Persistence.DTOs;

namespace HealthcareHMS.API.Controllers;

[ApiController]
//[Authorize(Roles = "GlobalAdmin")]
[Produces("applivation/json")]
[Route("api/[controller]")]
public class GlobalAdminController : BaseController
{
    private readonly IMapper _mapper;

    public GlobalAdminController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost("create-department")]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto departmentDto)
    {
        var command = _mapper.Map<CreateDepartmentCommand>(departmentDto);
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(CreateDepartment), new { id = result.Id }, result);
    }
}