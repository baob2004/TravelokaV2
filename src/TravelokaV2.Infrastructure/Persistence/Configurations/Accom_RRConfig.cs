using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class Accom_RRConfig : IEntityTypeConfiguration<Accom_RR>
    {
        public void Configure(EntityTypeBuilder<Accom_RR> builder)
        {
            builder.ToTable("Accom_RR");

            builder.HasOne(x => x.Accommodation)
            .WithMany(x => x.Accom_RRs)
            .HasForeignKey(x => x.AccomId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ReviewsAndRating)
            .WithMany(x => x.Accom_RRs)
            .HasForeignKey(x => x.RRId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
