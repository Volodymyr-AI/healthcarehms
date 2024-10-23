using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Doctors.Commands.CreateDoctorInfo
{
    public class CreateDoctorInfoCommand : IRequest<Guid>
    {
        public Guid HospitalAdminId { get; set; }

    }
}
