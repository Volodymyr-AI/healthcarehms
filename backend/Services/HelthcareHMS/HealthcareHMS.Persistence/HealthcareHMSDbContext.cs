using HealthcareHMS.Application.Utils.Interfaces.Infrastructure;
using HealthcareHMS.Core;
using HealthcareHMS.Core.HospitalRelatedEntities;
using HealthcareHMS.Persistence.Configurations;
using HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;
using HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;
using Microsoft.EntityFrameworkCore;

namespace HealthcareHMS.Persistence;

public class HealthcareHMSDbContext : DbContext, IHealthcareHMSDbContext
{
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<HospitalEntity> Hospitals { get; set; }
    public DbSet<HospitalAdminEntity> HospitalAdmins { get; set; }
    public DbSet<DoctorWorkinghoursEntity> WorkHours { get; set; }
    public DbSet<CertificationEntity> Certifications { get; set; }
    public DbSet<ConditionTreatedEntity> ConditionTreated { get; set; }
    public DbSet<DoctorPhoneNumberEntity> DoctorPhoneNumbers { get; set; }
    public DbSet<HospitalPhoneNumberEntity> HospitalPhoneNumbers { get; set; }
    public DbSet<LicenseEntity> Licenses { get; set; }
    public DbSet<PractiseEntity> Practises { get; set; }
    public DbSet<ServiceProvidedEntity> ServiceProvided { get; set; }
    public DbSet<HospitalFacilityEntity> HospitalFacilities { get; set; }
    public DbSet<HospitalServiceEntity> HospitalServices { get; set; }

    public HealthcareHMSDbContext(DbContextOptions<HealthcareHMSDbContext> options) : base(options)
    {
        // Empty 200
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DoctorConfiguration());
        builder.ApplyConfiguration(new HospitalConfiguration());
        builder.ApplyConfiguration(new HospitalAdminConfiguration());
        builder.ApplyConfiguration(new WorkingHoursConfiguration());
        builder.ApplyConfiguration(new CertificationConfiguration());
        builder.ApplyConfiguration(new ConditionTreatedConfiguration());
        builder.ApplyConfiguration(new LicenseConfiguration());
        builder.ApplyConfiguration(new PractiseConfiguration());
        builder.ApplyConfiguration(new ServicesProvidedConfiguration());
        builder.ApplyConfiguration(new HospitalFacilityConfiguration());
        builder.ApplyConfiguration(new HospitalPhoneNumberConfiguration());
        builder.ApplyConfiguration(new HospitalServiceConfiguration());
        base.OnModelCreating(builder); 
    }
}