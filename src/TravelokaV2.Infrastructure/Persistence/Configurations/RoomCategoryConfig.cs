using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class RoomCategoryConfig : IEntityTypeConfiguration<RoomCategory>
    {
        public void Configure(EntityTypeBuilder<RoomCategory> builder)
        {
            builder.ToTable("RoomCategories");

            builder.HasOne<Accommodation>()
            .WithMany(x => x.RoomCategories)
            .HasForeignKey(x => x.AccomId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}