using AutoMapper;
using StaffMS.Application.MediatR.GlobalAdmin.Department.Commands.Create;
using StaffMS.Application.Utils.Mapping;

namespace StaffMS.Persistence.DTOs;

public class CreateDepartmentDto : IMapWith<CreateDepartmentCommand>
{
    public string HospitalName { get; set; }
    public string Email { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDepartmentDto, CreateDepartmentCommand>()
            .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.HospitalName))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email));
    }

}