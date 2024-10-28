﻿using System.Reflection;
using AutoMapper;

namespace StaffMS.Application.Utils.Mapping;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyMappingFromAssembly(assembly);

    private void ApplyMappingFromAssembly(Assembly assembly) // realisation of mapping
    {                                                        // method scans assembly and searches 
        {                                                    // all types that implement IMapWith interface   
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}