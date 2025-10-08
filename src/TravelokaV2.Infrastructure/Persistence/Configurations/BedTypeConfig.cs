using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class BedTypeConfig : IEntityTypeConfiguration<BedType>
    {
        public void Configure(EntityTypeBuilder<BedType> builder)
        {
            builder.ToTable("BedTypes");
        }
    }
}