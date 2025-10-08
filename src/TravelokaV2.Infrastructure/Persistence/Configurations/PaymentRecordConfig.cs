using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class PaymentRecordConfig : IEntityTypeConfiguration<PaymentRecord>
    {
        public void Configure(EntityTypeBuilder<PaymentRecord> builder)
        {
            builder.ToTable("PaymentRecords");
        }
    }
}