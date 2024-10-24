using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Authorize(Roles = "GlobalAdmin")]
    public class GlobalAdminController : BaseController
    {
        private readonly IMapper _mapper;

        public GlobalAdminController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateHospital([FromBody] UpdateHospitalCommand)
    }
}
