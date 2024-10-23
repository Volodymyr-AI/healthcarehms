using MediatR;

namespace HospitalManagement.Application.Doctors.Commands.CreateDoctorInfo
{
    public class CreateDoctorInfoCommand : IRequest<Guid>
    {
        public Guid HospitalAdminId { get; set; }
        
    }
}
