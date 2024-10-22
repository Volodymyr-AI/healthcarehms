using HospitalManagement.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Persistance.Configuration
{
    public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHoursEntity>
    {
        public void Configure(EntityTypeBuilder<WorkingHoursEntity> entityTypeConfiguration)
        {

        }
    }
}
