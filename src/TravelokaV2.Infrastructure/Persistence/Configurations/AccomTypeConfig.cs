using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class AccomTypeConfig : IEntityTypeConfiguration<AccomType>
    {
        public void Configure(EntityTypeBuilder<AccomType> builder)
        {
            builder.ToTable("AccomTypes");

            builder.HasMany(t => t.Accommodations)
                   .WithOne(a => a.AccomType)
                   .HasForeignKey(a => a.AccomTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}