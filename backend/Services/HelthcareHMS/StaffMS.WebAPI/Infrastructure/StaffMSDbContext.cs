using Microsoft.EntityFrameworkCore;
using StaffMS.WebAPI.Domain.Additional;
using StaffMS.WebAPI.Domain.UserRelated;
using StaffMS.WebAPI.Infrastructure.Configurations.AdditionalEntitiesConfigs;
using StaffMS.WebAPI.Infrastructure.Configurations.BaseEntitiesConfigs;

namespace StaffMS.WebAPI.Infrastructure;

public class StaffMSDbContext : DbContext
{
    public DbSet<GlobalAdminEntity> GlobalAdmins { get; set; }
    public DbSet<StaffMemberEntity> StaffMembers { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<StaffAdminEntity> StaffAdmins { get; set; }
    public DbSet<ShiftHoursEntity> WorkHours { get; set; }
    public DbSet<CertificationEntity> Certifications { get; set; }
    public DbSet<SpecialisationEntity> Specialisations { get; set; }
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
        //Base
        builder.ApplyConfiguration(new StaffMemberConfiguration());
        builder.ApplyConfiguration(new DepartmentConfiguration());
        builder.ApplyConfiguration(new StaffAdminConfiguration());
        builder.ApplyConfiguration(new GlobalAdminConfiguration());
        //Additional
        builder.ApplyConfiguration(new CertificationConfiguration());
        builder.ApplyConfiguration(new DepartmentServiceConfiguration());
        builder.ApplyConfiguration(new FacilityConfiguration());
        builder.ApplyConfiguration(new LicenseConfiguration());
        builder.ApplyConfiguration(new PhoneNumberConfiguration());
        builder.ApplyConfiguration(new PractiseConfiguration());
        builder.ApplyConfiguration(new ShiftHoursConfiguration());
        builder.ApplyConfiguration(new SpecialisationConfiguration());
        builder.ApplyConfiguration(new StaffServiceConfiguration());
        base.OnModelCreating(builder); 
    }

}