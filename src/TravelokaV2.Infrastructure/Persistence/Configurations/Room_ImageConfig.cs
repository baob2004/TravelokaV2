using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class Room_ImageConfig : IEntityTypeConfiguration<Room_Image>
    {
        public void Configure(EntityTypeBuilder<Room_Image> builder)
        {
            builder.ToTable("Room_Images");

            builder.HasIndex(x => new { x.RoomCategoryId, x.ImageId }).IsUnique();

            builder.HasOne(x => x.RoomCategory)
            .WithMany(x => x.Room_Images)
            .HasForeignKey(x => x.RoomCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Image)
            .WithMany(x => x.Room_Images)
            .HasForeignKey(x => x.ImageId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => x.RoomCategory != null && !x.RoomCategory.IsDeleted);

        }
    }
}
