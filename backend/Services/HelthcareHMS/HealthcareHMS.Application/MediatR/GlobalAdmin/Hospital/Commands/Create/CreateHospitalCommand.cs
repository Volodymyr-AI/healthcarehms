using HealthcareHMS.Core;
using HealthcareHMS.Core.HospitalRelatedEntities;
using MediatR;

namespace HealthcareHMS.Application.MediatR.GlobalAdmin.Hospital.Commands.Create;

public class CreateHospitalCommand : IRequest<HospitalEntity>
{
    public string HospitalName { get; set; }
    public string Email { get; set; }
    public Guid GlobalAdminId { get; set; }
}