using HospitalManagement.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Persistance.Configuration
{
    public class HospitalConfiguration : IEntityTypeConfiguration<HospitalEntity>
    {
        public void Configure(EntityTypeBuilder<HospitalEntity> builder)
        {
            builder.HasKey(x => x.Id); // Id is our key
        }
    }
    }
}
