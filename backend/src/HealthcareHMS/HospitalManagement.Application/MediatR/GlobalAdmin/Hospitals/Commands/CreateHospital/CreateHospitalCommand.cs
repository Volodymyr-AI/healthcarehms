using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.CreateHospital
{
    public class CreateHospitalCommand : IRequest<Guid>
    {
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
