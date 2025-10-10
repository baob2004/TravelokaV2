using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class PolicyConfig : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");

            builder.HasKey(x => x.AccomId);

            builder.Property(x => x.AccomId)
             .ValueGeneratedNever()
             .HasColumnName("AccommodationId");

            builder.HasOne(x => x.Accommodation)
             .WithOne(a => a.Policy)
             .HasForeignKey<Policy>(x => x.AccomId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => x.Accommodation != null && !x.Accommodation.IsDeleted);
        }
    }
}