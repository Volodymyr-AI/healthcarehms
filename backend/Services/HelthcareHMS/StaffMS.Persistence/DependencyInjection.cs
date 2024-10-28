using StaffMS.Application.Utils.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffMS.Application.Utils.Interfaces.Repositories;
using StaffMS.Core;
using StaffMS.Persistence;
using StaffMS.Persistence.Repositories;

namespace StaffMS.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("StaffMSConnection");
        services.AddDbContext<StaffMSDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IStaffMSDbContext>(provider => 
            provider.GetService<StaffMSDbContext>());
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        return services;
    }
}