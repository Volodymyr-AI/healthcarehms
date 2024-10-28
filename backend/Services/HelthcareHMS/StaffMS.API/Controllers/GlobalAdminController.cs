using StaffMS.Application.Utils.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareHMS.API.Controllers;

//[ApiVersion("2.0")]
//[ApiVersionNeutral] // so controller will work no paying attention to the version
[Produces("applivation/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class GlobalAdminController : BaseController
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMediator _mediator;
    

    public GlobalAdminController(IDepartmentRepository departmentRepository, IMediator mediator)
    {
        _departmentRepository = departmentRepository;
        _mediator = mediator;
    }
}