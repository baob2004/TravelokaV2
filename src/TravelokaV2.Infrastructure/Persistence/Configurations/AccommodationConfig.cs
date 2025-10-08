using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class AccommodationConfig : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodations");

            builder.HasOne(x => x.Policy)
             .WithOne(p => p.Accommodation)
             .HasForeignKey<Policy>(p => p.AccomId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GeneralInfo)
             .WithOne(g => g.Accommodation)
             .HasForeignKey<GeneralInfo>(g => g.AccomId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}