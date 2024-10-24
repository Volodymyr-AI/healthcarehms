using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagement.API.Controllers
{
    [Authorize(Roles = "HospitalAdmin")]
    public class HospitalAdminController : BaseController
    {
        IMapper _mapper;

        public HospitalAdminController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
