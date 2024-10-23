using Hospital.Persistance.Configuration;
using HospitalManagement.Application.Utils.Interfaces;
using HospitalManagement.Core;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Persistance
{
    public class HospitalDbContext : DbContext, IHospitalDbContext
    {
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<HospitalEntity> Hospitals {  get; set; }
        public DbSet<WorkingHoursEntity> WorkHours { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
            // Empty 200
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new HospitalConfiguration());
            builder.ApplyConfiguration(new WorkingHoursConfiguration());
            base.OnModelCreating(builder); 
        }
    }
}
