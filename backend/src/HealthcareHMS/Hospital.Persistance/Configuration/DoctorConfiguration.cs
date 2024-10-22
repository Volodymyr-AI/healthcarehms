using Microsoft.EntityFrameworkCore;
using HospitalManagement.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Persistance.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(x => x.Id); // Id is our key
        }
    }
}
