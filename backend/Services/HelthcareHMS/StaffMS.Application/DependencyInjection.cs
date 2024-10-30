using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using StaffMS.Application.Utils.Behaviours;

namespace StaffMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Register mediatr 
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(Application.AssemblyMarker).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}