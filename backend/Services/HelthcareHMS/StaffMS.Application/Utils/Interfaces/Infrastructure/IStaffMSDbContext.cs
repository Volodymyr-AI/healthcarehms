using StaffMS.Core;
using StaffMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;

namespace StaffMS.Application.Utils.Interfaces.Infrastructure;

public interface IStaffMSDbContext : IDisposable
{
    DbSet<StaffMemberEntity> StaffMembers { get; set; }
    DbSet<DepartmentEntity> Departments { get; set; }
    DbSet<StaffAdminEntity> StaffAdmins { get; set; }
    DbSet<StaffWorkinghoursEntity> WorkHours { get; set; }
    DbSet<CertificationEntity> Certifications { get; set; }
    DbSet<Specialisations> Specialisations { get; set; }
    DbSet<StaffPhoneNumberEntity> StaffPhoneNumbers { get; set; }
    DbSet<LicenseEntity> Licenses { get; set; }
    DbSet<PractiseEntity> Practises { get; set; }
    DbSet<ServiceProvidedEntity> ServiceProvided { get; set; }
    DbSet<DepartmentFacilityEntity> DepartmentFacilities { get; set; }
    DbSet<DepartmentPhoneNumberEntity> DepartmentPhoneNumbers { get; set; }
    DbSet<DepartmentServiceEntity> DepartmentServices { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // save changes to Db
}