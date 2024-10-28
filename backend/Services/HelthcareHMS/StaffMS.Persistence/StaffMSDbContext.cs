using StaffMS.Core;
using StaffMS.Core.HospitalRelatedEntities;
using HealthcareHMS.Persistence.Configurations;
using HealthcareHMS.Persistence.Configurations.DoctorRelatedConfigurations;
using HealthcareHMS.Persistence.Configurations.HospitalRelatedConfigurattions;
using Microsoft.EntityFrameworkCore;
using StaffMS.Application.Utils.Interfaces.Infrastructure;

namespace StaffMS.Persistence;

public class StaffMSDbContext : DbContext, IStaffMSDbContext
{
    public DbSet<StaffMemberEntity> StaffMembers { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<StaffAdminEntity> StaffAdmins { get; set; }
    public DbSet<StaffWorkinghoursEntity> WorkHours { get; set; }
    public DbSet<CertificationEntity> Certifications { get; set; }
    public DbSet<Specialisations> Specialisations { get; set; }
    public DbSet<StaffPhoneNumberEntity> StaffPhoneNumbers { get; set; }
    public DbSet<DepartmentPhoneNumberEntity> DepartmentPhoneNumbers { get; set; }
    public DbSet<LicenseEntity> Licenses { get; set; }
    public DbSet<PractiseEntity> Practises { get; set; }
    public DbSet<ServiceProvidedEntity> ServiceProvided { get; set; }
    public DbSet<DepartmentFacilityEntity> DepartmentFacilities { get; set; }
    public DbSet<DepartmentServiceEntity> DepartmentServices { get; set; }

    public StaffMSDbContext(DbContextOptions<StaffMSDbContext> options) : base(options)
    {
        // Empty 200
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StaffConfiguration());
        builder.ApplyConfiguration(new DepartmentConfiguration());
        builder.ApplyConfiguration(new StaffAdminConfiguration());
        builder.ApplyConfiguration(new WorkingHoursConfiguration());
        builder.ApplyConfiguration(new CertificationConfiguration());
        builder.ApplyConfiguration(new ConditionTreatedConfiguration());
        builder.ApplyConfiguration(new LicenseConfiguration());
        builder.ApplyConfiguration(new PractiseConfiguration());
        builder.ApplyConfiguration(new ServicesProvidedConfiguration());
        builder.ApplyConfiguration(new DepartmentFacilityConfiguration());
        builder.ApplyConfiguration(new DepartmentPhoneNumberConfiguration());
        builder.ApplyConfiguration(new DepartmentServiceConfiguration());
        base.OnModelCreating(builder); 
    }
}