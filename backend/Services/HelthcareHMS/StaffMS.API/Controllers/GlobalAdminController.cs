using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;
using StaffMS.Core;
using StaffMS.Persistence.DTOs;

namespace StaffMS.API.Controllers;

[ApiController]
//[Authorize(Roles = "GlobalAdmin")]
[Produces("application/json")]
[Route("api/[controller]")]
public class GlobalAdminController : BaseController
{
    private readonly IMapper _mapper;

    public GlobalAdminController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost("create-department")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<DepartmentEntity>> CreateDepartment([FromBody] CreateDepartmentCommand department)
    {
        var result = await Mediator.Send(department);
        return Ok(result);
    }
}