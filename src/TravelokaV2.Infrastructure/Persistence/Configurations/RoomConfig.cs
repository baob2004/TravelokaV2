using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

public class RoomConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasOne(r => r.RoomCategory)
               .WithMany(rc => rc.Rooms)
               .HasForeignKey(r => r.CategoryId)     // <— map đúng FK
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.BedType)
               .WithMany()
               .HasForeignKey(r => r.BedTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(r => r.CancelPolicy)
               .WithMany()
               .HasForeignKey(r => r.CancelPolicyId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
