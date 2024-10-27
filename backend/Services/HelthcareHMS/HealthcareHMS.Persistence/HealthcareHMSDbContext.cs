using HealthcareHMS.Application.Utils.Interfaces.Infrastructure;
using HealthcareHMS.Core;
using HealthcareHMS.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HealthcareHMS.Persistence;

public class HealthcareHMSDbContext : DbContext, IHealthcareHMSDbContext
{
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<HospitalEntity> Hospitals {  get; set; }
    public DbSet<DoctorWorkinghoursEntity> WorkHours { get; set; }
    public DbSet<HospitalAdminEntity> HospitalAdmins { get; set; }

    public HealthcareHMSDbContext(DbContextOptions<HealthcareHMSDbContext> options) : base(options)
    {
        // Empty 200
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DoctorConfiguration());
        builder.ApplyConfiguration(new HospitalConfiguration());
        builder.ApplyConfiguration(new WorkingHoursConfiguration());
        builder.ApplyConfiguration(new HospitalAdminConfiguration());
        base.OnModelCreating(builder); 
    }
}