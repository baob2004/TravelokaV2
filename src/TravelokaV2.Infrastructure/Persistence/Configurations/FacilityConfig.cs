using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class FacilityConfig : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facilities");
        }
    }
}