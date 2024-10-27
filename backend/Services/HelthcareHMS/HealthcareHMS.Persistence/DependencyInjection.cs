using HealthcareHMS.Application.Utils.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthcareHMS.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HealthcareHMSConnection");
        services.AddDbContext<HealthcareHMSDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IHealthcareHMSDbContext>(provider => 
            provider.GetService<HealthcareHMSDbContext>());
        return services;
    }
}