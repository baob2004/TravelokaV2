using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class Accom_ImageConfig : IEntityTypeConfiguration<Accom_Image>
    {
        public void Configure(EntityTypeBuilder<Accom_Image> builder)
        {
            builder.ToTable("Accom_Images");

            builder.HasIndex(x => new { x.AccomId, x.ImageId }).IsUnique();

            builder.HasOne(x => x.Accommodation)
            .WithMany(x => x.Accom_Images)
            .HasForeignKey(x => x.AccomId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Image)
            .WithMany(x => x.Accom_Images)
            .HasForeignKey(x => x.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => x.Accommodation != null && !x.Accommodation.IsDeleted);
        }
    }
}
