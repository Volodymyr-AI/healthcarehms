using HospitalManagement.Core;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Application.Interfaces
{
    public interface IHospitalDbContext : IDisposable
    {
        DbSet<DoctorEntity> Doctors { get; set; }
        DbSet<HospitalEntity> Hospitals { get; set; }
        DbSet<WorkingHoursEntity> WorkHours { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); // save changes to Db
    }
}
