using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StaffMS.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => 
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    internal Guid UserId =>
        User.Identity != null && !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    
    internal bool IsInRole(string roleName) => User.IsInRole(roleName);
}