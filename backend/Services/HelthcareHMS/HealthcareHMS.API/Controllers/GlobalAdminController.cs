using Microsoft.AspNetCore.Mvc;

namespace HealthcareHMS.API.Controllers;

//[ApiVersion("2.0")]
//[ApiVersionNeutral] // so controller will work no paying attention to the version
[Produces("applivation/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class GlobalAdminController : BaseController
{
    
}