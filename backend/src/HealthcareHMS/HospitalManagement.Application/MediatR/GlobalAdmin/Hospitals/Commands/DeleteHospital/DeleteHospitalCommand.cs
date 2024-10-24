using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.DeleteHospital
{
    public class DeleteHospitalCommand : IRequest<Unit>
    {
        public Guid HospitalId { get; set; }
        public Guid GlobalAdminId { get; set; }
    }
}
