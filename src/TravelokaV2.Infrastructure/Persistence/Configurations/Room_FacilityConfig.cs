using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class Room_FacilityConfig : IEntityTypeConfiguration<Room_Facility>
    {
        public void Configure(EntityTypeBuilder<Room_Facility> builder)
        {
            builder.ToTable("Room_Facilities");

            builder.HasIndex(x => new { x.RoomCategoryId, x.FacilityId }).IsUnique();

            builder.HasOne(x => x.RoomCategory)
            .WithMany(x => x.Room_Facilities)
            .HasForeignKey(x => x.RoomCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Facility)
            .WithMany(x => x.Room_Facilities)
            .HasForeignKey(x => x.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}