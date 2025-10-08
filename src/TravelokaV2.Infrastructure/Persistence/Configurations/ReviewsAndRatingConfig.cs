using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelokaV2.Domain.Entities;
using TravelokaV2.Infrastructure.Identity;

namespace TravelokaV2.Infrastructure.Persistence.Configurations
{
    public class ReviewsAndRatingConfig : IEntityTypeConfiguration<ReviewsAndRating>
    {
        public void Configure(EntityTypeBuilder<ReviewsAndRating> builder)
        {
            builder.ToTable("ReviewsAndRatings");

            builder.HasOne<AppUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}