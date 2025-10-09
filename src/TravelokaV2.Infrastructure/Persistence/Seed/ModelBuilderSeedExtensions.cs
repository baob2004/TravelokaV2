using Microsoft.EntityFrameworkCore;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Seed
{
    public static class ModelBuilderSeedExtensions
    {
        // fixed GUIDs để giữ quan hệ
        private static readonly Guid AccomType_Hotel = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private static readonly Guid AccomType_Resort = Guid.Parse("22222222-2222-2222-2222-222222222222");

        private static readonly Guid Facility_Wifi = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly Guid Facility_Pool = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        private static readonly Guid Facility_Gym = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        private static readonly Guid BedType_Queen = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        private static readonly Guid BedType_Twin = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        private static readonly Guid CancelPolicy_Flex = Guid.Parse("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1");

        private static readonly Guid Img_1 = Guid.Parse("99999999-0000-0000-0000-000000000001");
        private static readonly Guid Img_2 = Guid.Parse("99999999-0000-0000-0000-000000000002");

        private static readonly Guid Accom_Alpha = Guid.Parse("aaaa1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Beta = Guid.Parse("bbbb1111-2222-3333-4444-555566667777");

        private static readonly Guid RC_AlphaStd = Guid.Parse("12121212-3434-5656-7878-909090909090");
        private static readonly Guid RC_BetaDelx = Guid.Parse("23232323-4545-6767-8989-010101010101");

        private static readonly DateTime SeedNow = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);

        public static void Seed(this ModelBuilder b)
        {
            // AccomType
            b.Entity<AccomType>().HasData(
                new AccomType { Id = AccomType_Hotel, Type = "Hotel", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Resort, Type = "Resort", CreatedAt = SeedNow }
            );

            // Facility
            b.Entity<Facility>().HasData(
                new Facility { Id = Facility_Wifi, Name = "Free Wi-Fi", Icon = "wifi", CreatedAt = SeedNow },
                new Facility { Id = Facility_Pool, Name = "Pool", Icon = "pool", CreatedAt = SeedNow },
                new Facility { Id = Facility_Gym, Name = "Gym", Icon = "dumbbell", CreatedAt = SeedNow }
            );

            // BedType
            b.Entity<BedType>().HasData(
                new BedType { Id = BedType_Queen, Type = "Queen", CreatedAt = SeedNow },
                new BedType { Id = BedType_Twin, Type = "Twin", CreatedAt = SeedNow }
            );

            // CancelPolicy
            b.Entity<CancelPolicy>().HasData(
                new CancelPolicy { Id = CancelPolicy_Flex, Type = "Flexible (24h)", CreatedAt = SeedNow }
            );

            // Image
            b.Entity<Image>().HasData(
                new Image { Id = Img_1, Url = "https://picsum.photos/id/1018/600/400", Alt = "Lobby", CreatedAt = SeedNow },
                new Image { Id = Img_2, Url = "https://picsum.photos/id/1015/600/400", Alt = "Room", CreatedAt = SeedNow }
            );

            // Accommodation
            b.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    Id = Accom_Alpha,
                    Name = "Alpha Hotel",
                    Email = "contact@alpha.example",
                    Phone = "+84 123 456 789",
                    AccomTypeId = AccomType_Hotel,
                    Star = 4,
                    Rating = 8.6f,
                    Address = "01 Main St, District 1, HCMC",
                    Location = "Ho Chi Minh City",
                    GgMapsQuery = "Alpha+Hotel+HCMC",
                    Ll = "10.776,106.700",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Beta,
                    Name = "Beta Resort",
                    Email = "hello@beta.example",
                    Phone = "+84 987 654 321",
                    AccomTypeId = AccomType_Resort,
                    Star = 5,
                    Rating = 9.1f,
                    Address = "Beach Rd, Nha Trang",
                    Location = "Nha Trang",
                    GgMapsQuery = "Beta+Resort+Nha+Trang",
                    Ll = "12.245,109.195",
                    CreatedAt = SeedNow
                }
            );

            // RoomCategory
            b.Entity<RoomCategory>().HasData(
                new RoomCategory
                {
                    Id = RC_AlphaStd,
                    Name = "Standard",
                    AccomId = Accom_Alpha,
                    About = "Cozy 20m2",
                    CreatedAt = SeedNow
                },
                new RoomCategory
                {
                    Id = RC_BetaDelx,
                    Name = "Deluxe Sea View",
                    AccomId = Accom_Beta,
                    About = "Spacious 32m2, balcony",
                    CreatedAt = SeedNow
                }
            );

            // Room
            b.Entity<Room>().HasData(
                new Room
                {
                    Id = Guid.Parse("77777777-0000-0000-0000-000000000001"),
                    Name = "A-101",
                    Breakfast = true,
                    NumberOfBeds = 1,
                    BedTypeId = BedType_Queen,
                    CancelPolicyId = CancelPolicy_Flex,
                    Available = true,
                    CategoryId = RC_AlphaStd,
                    Rating = 8.5f,
                    CreatedAt = SeedNow
                },
                new Room
                {
                    Id = Guid.Parse("77777777-0000-0000-0000-000000000002"),
                    Name = "B-201",
                    Breakfast = true,
                    NumberOfBeds = 2,
                    BedTypeId = BedType_Twin,
                    CancelPolicyId = CancelPolicy_Flex,
                    Available = true,
                    CategoryId = RC_BetaDelx,
                    Rating = 9.2f,
                    CreatedAt = SeedNow
                }
            );

            // Joins: Accom_Facility
            b.Entity<Accom_Facility>().HasData(
                new Accom_Facility { Id = Guid.Parse("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), AccomId = Accom_Alpha, FacilityId = Facility_Wifi },
                new Accom_Facility { Id = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), AccomId = Accom_Alpha, FacilityId = Facility_Pool },
                new Accom_Facility { Id = Guid.Parse("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"), AccomId = Accom_Beta, FacilityId = Facility_Wifi },
                new Accom_Facility { Id = Guid.Parse("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"), AccomId = Accom_Beta, FacilityId = Facility_Gym }
            );

            // Joins: Accom_Image
            b.Entity<Accom_Image>().HasData(
                new Accom_Image { Id = Guid.Parse("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), AccomId = Accom_Alpha, ImageId = Img_1 },
                new Accom_Image { Id = Guid.Parse("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), AccomId = Accom_Alpha, ImageId = Img_2 },
                new Accom_Image { Id = Guid.Parse("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), AccomId = Accom_Beta, ImageId = Img_2 }
            );
        }
    }
}
