using HealthcareHMS.Core;
using Microsoft.EntityFrameworkCore;

namespace HealthcareHMS.Application.Utils.Interfaces.Infrastructure;

public interface IHealthcareHMSDbContext : IDisposable
{
    DbSet<DoctorEntity> Doctors { get; set; }
    DbSet<HospitalEntity> Hospitals { get; set; }
    DbSet<DoctorWorkinghoursEntity> WorkHours { get; set; }
    DbSet<HospitalAdminEntity> HospitalAdmins { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); // save changes to Db
}