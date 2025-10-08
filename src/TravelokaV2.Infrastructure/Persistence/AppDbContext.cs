using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Infrastructure.Identity;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Accom_Facility> AccomFacilities { get; set; } = default!;
        public DbSet<Accom_Image> AccomImages { get; set; } = default!;
        public DbSet<Accom_RR> AccomRRs { get; set; } = default!;
        public DbSet<Accommodation> Accommodations { get; set; } = default!;
        public DbSet<AccomType> AccomTypes { get; set; } = default!;
        public DbSet<BedType> BedTypes { get; set; } = default!;
        public DbSet<CancelPolicy> CancelPolicies { get; set; } = default!;
        public DbSet<Facility> Facilities { get; set; } = default!;
        public DbSet<GeneralInfo> GeneralInfos { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = default!;
        public DbSet<PaymentRecord> PaymentRecords { get; set; } = default!;
        public DbSet<Policy> Policies { get; set; } = default!;
        public DbSet<ReviewsAndRating> ReviewsAndRatings { get; set; } = default!;
        public DbSet<Room_Image> RoomImages { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<RoomCategory> RoomCategories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
