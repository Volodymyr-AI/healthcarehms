using AutoMapper;

namespace StaffMS.Application.Utils.Mapping;

public interface IMapWith<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}