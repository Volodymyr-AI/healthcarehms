using MediatR;

namespace HospitalManagement.Application.MediatR.GlobalAdmin.Hospitals.Commands.UpdateHospital
{
    public class UpdateHospitalGACommand : IRequest<Unit>
    {
        public Guid HospitalId { get; set; }
        // add features that can be changed only by the GlobalAdmin
        public bool AddGoogleMyBusiness { get; set; }
    }
}
