using HealthcareHMS.Core;
using HealthcareHMS.Core.HospitalRelatedEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareHMS.Application.Utils.Interfaces.Infrastructure;

public interface IHealthcareHMSDbContext : IDisposable
{
    DbSet<DoctorEntity> Doctors { get; set; }
    DbSet<HospitalEntity> Hospitals { get; set; }
    DbSet<HospitalAdminEntity> HospitalAdmins { get; set; }
    DbSet<DoctorWorkinghoursEntity> WorkHours { get; set; }
    DbSet<CertificationEntity> Certifications { get; set; }
    DbSet<ConditionTreatedEntity> ConditionTreated { get; set; }
    DbSet<DoctorPhoneNumberEntity> DoctorPhoneNumbers { get; set; }
    DbSet<LicenseEntity> Licenses { get; set; }
    DbSet<PractiseEntity> Practises { get; set; }
    DbSet<ServiceProvidedEntity> ServiceProvided { get; set; }
    DbSet<HospitalFacilityEntity> HospitalFacilities { get; set; }
    DbSet<HospitalPhoneNumberEntity> HospitalPhoneNumbers { get; set; }
    DbSet<HospitalServiceEntity> HospitalServices { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // save changes to Db
}