using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class Accom_FacilityConfig : IEntityTypeConfiguration<Accom_Facility>
    {
        public void Configure(EntityTypeBuilder<Accom_Facility> builder)
        {
            builder.ToTable("Accom_Facilities");

            builder.HasIndex(x => new { x.AccomId, x.FacilityId }).IsUnique();

            builder.HasOne(x => x.Accommodation)
             .WithMany(a => a.Accom_Facilities)
             .HasForeignKey(x => x.AccomId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Facility)
             .WithMany(f => f.Accom_Facilities)
             .HasForeignKey(x => x.FacilityId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
