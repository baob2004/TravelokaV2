using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class GeneralInfoConfig : IEntityTypeConfiguration<GeneralInfo>
    {
        public void Configure(EntityTypeBuilder<GeneralInfo> builder)
        {
            builder.ToTable("GeneralInfos");

            builder.HasKey(x => x.AccomId);

            builder.Property(x => x.AccomId)
             .ValueGeneratedNever()
             .HasColumnName("AccommodationId");

            builder.HasOne(x => x.Accommodation)
             .WithOne(a => a.GeneralInfo)
             .HasForeignKey<GeneralInfo>(x => x.AccomId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}