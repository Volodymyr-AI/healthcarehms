using AutoMapper;
using HealthcareHMS.Application.MediatR.GlobalAdmin.Hospital.Commands.Create;
using HealthcareHMS.Application.Utils.Mapping;

namespace HealthcareHMS.Persistence.DTO.HospitalDTOs;

public class CreateHospitalDTO : IMapWith<CreateHospitalCommand>
{
    public string HospitalName { get; set; }
    public string Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHospitalDTO, CreateHospitalCommand>()
            .ForMember(x => x.HospitalName, opt => opt.MapFrom(x => x.HospitalName))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email));
    }
}