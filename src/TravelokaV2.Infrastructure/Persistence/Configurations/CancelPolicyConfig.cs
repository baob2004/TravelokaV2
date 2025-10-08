using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class CancelPolicyConfig : IEntityTypeConfiguration<CancelPolicy>
    {
        public void Configure(EntityTypeBuilder<CancelPolicy> builder)
        {
            builder.ToTable("CancelPolicies");
        }
    }
}