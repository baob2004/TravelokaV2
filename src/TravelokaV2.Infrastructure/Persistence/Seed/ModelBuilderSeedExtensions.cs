using Microsoft.EntityFrameworkCore;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Seed
{
    public static class ModelBuilderSeedExtensions
    {
        // ===== Fixed GUIDs: Types =====
        private static readonly Guid AccomType_Hotel = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private static readonly Guid AccomType_Resort = Guid.Parse("22222222-2222-2222-2222-222222222222");
        private static readonly Guid AccomType_Apartment = Guid.Parse("33333333-3333-3333-3333-333333333333");
        private static readonly Guid AccomType_Villa = Guid.Parse("44444444-4444-4444-4444-444444444444");
        private static readonly Guid AccomType_Hostel = Guid.Parse("55555555-5555-5555-5555-555555555555");
        private static readonly Guid AccomType_Guesthouse = Guid.Parse("66666666-6666-6666-6666-666666666666");
        private static readonly Guid AccomType_Homestay = Guid.Parse("77777777-7777-7777-7777-777777777777");
        private static readonly Guid AccomType_Motel = Guid.Parse("88888888-8888-8888-8888-888888888888");
        private static readonly Guid AccomType_Capsule = Guid.Parse("99999999-9999-9999-9999-999999999999");
        private static readonly Guid AccomType_Bungalow = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly Guid AccomType_Farmstay = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        private static readonly Guid AccomType_Campsite = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        private static readonly Guid AccomType_Lodge = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        private static readonly Guid AccomType_Ryokan = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        private static readonly Guid AccomType_Riad = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // ===== Facilities (>=10) =====
        private static readonly Guid Facility_Wifi = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01");
        private static readonly Guid Facility_Pool = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02");
        private static readonly Guid Facility_Gym = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccc03");
        private static readonly Guid Facility_Spa = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04");
        private static readonly Guid Facility_Parking = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05");
        private static readonly Guid Facility_Restaurant = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06");
        private static readonly Guid Facility_Bar = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07");
        private static readonly Guid Facility_Shuttle = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08");
        private static readonly Guid Facility_Reception = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09");
        private static readonly Guid Facility_Laundry = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10");

        // ===== BedTypes (10) =====
        private static readonly Guid BedType_Queen = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddd04");
        private static readonly Guid BedType_Twin = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee05");
        private static readonly Guid BedType_Single = Guid.Parse("bead0000-0000-0000-0000-000000000001");
        private static readonly Guid BedType_Double = Guid.Parse("bead0000-0000-0000-0000-000000000002");
        private static readonly Guid BedType_King = Guid.Parse("bead0000-0000-0000-0000-000000000003");
        private static readonly Guid BedType_SuperKing = Guid.Parse("bead0000-0000-0000-0000-000000000004");
        private static readonly Guid BedType_Bunk = Guid.Parse("bead0000-0000-0000-0000-000000000005");
        private static readonly Guid BedType_SofaBed = Guid.Parse("bead0000-0000-0000-0000-000000000006");
        private static readonly Guid BedType_Futon = Guid.Parse("bead0000-0000-0000-0000-000000000007");
        private static readonly Guid BedType_Tatami = Guid.Parse("bead0000-0000-0000-0000-000000000008");

        // ===== CancelPolicy (10) =====
        private static readonly Guid CancelPolicy_Flex = Guid.Parse("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1");
        private static readonly Guid CancelPolicy_48h = Guid.Parse("cafe0000-0000-0000-0000-000000000001");
        private static readonly Guid CancelPolicy_72h = Guid.Parse("cafe0000-0000-0000-0000-000000000002");
        private static readonly Guid CancelPolicy_7d = Guid.Parse("cafe0000-0000-0000-0000-000000000003");
        private static readonly Guid CancelPolicy_14d = Guid.Parse("cafe0000-0000-0000-0000-000000000004");
        private static readonly Guid CancelPolicy_NonRefund = Guid.Parse("cafe0000-0000-0000-0000-000000000005");
        private static readonly Guid CancelPolicy_NoShow1Night = Guid.Parse("cafe0000-0000-0000-0000-000000000006");
        private static readonly Guid CancelPolicy_FreeUntil18h = Guid.Parse("cafe0000-0000-0000-0000-000000000007");
        private static readonly Guid CancelPolicy_SemiFlex = Guid.Parse("cafe0000-0000-0000-0000-000000000008");
        private static readonly Guid CancelPolicy_SuperFlex = Guid.Parse("cafe0000-0000-0000-0000-000000000009");

        // ===== Images (10) =====
        private static readonly Guid Img_1 = Guid.Parse("99999999-0000-0000-0000-000000000001");
        private static readonly Guid Img_2 = Guid.Parse("99999999-0000-0000-0000-000000000002");
        private static readonly Guid Img_3 = Guid.Parse("99999999-0000-0000-0000-000000000003");
        private static readonly Guid Img_4 = Guid.Parse("99999999-0000-0000-0000-000000000004");
        private static readonly Guid Img_5 = Guid.Parse("99999999-0000-0000-0000-000000000005");
        private static readonly Guid Img_6 = Guid.Parse("99999999-0000-0000-0000-000000000006");
        private static readonly Guid Img_7 = Guid.Parse("99999999-0000-0000-0000-000000000007");
        private static readonly Guid Img_8 = Guid.Parse("99999999-0000-0000-0000-000000000008");
        private static readonly Guid Img_9 = Guid.Parse("99999999-0000-0000-0000-000000000009");
        private static readonly Guid Img_10 = Guid.Parse("99999999-0000-0000-0000-000000000010");

        // ===== Payment Methods (10) =====
        private static readonly Guid Pay_Cash = Guid.Parse("11112222-3333-4444-5555-666677778888");
        private static readonly Guid Pay_CreditCard = Guid.Parse("22223333-4444-5555-6666-777788889999");
        private static readonly Guid Pay_DebitCard = Guid.Parse("33334444-5555-6666-7777-88889999aaaa");
        private static readonly Guid Pay_Momo = Guid.Parse("44445555-6666-7777-8888-9999aaaabbbb");
        private static readonly Guid Pay_ZaloPay = Guid.Parse("55556666-7777-8888-9999-aaaabbbbcccc");
        private static readonly Guid Pay_BankTransfer = Guid.Parse("66667777-8888-9999-aaaa-bbbbccccdddd");
        private static readonly Guid Pay_ApplePay = Guid.Parse("77778888-9999-aaaa-bbbb-ccccddddeeee");
        private static readonly Guid Pay_GooglePay = Guid.Parse("88889999-aaaa-bbbb-cccc-ddddeeeeffff");
        private static readonly Guid Pay_VNPay = Guid.Parse("9999aaaa-bbbb-cccc-dddd-eeeeffff0000");
        private static readonly Guid Pay_PayPal = Guid.Parse("aaaa9999-bbbb-cccc-dddd-eeeeffff1111");

        // ===== Accommodations (10) =====
        private static readonly Guid Accom_Alpha = Guid.Parse("aaaa1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Beta = Guid.Parse("bbbb1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Gamma = Guid.Parse("cccc1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Delta = Guid.Parse("dddd1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Epsilon = Guid.Parse("eeee1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Zeta = Guid.Parse("ffff1111-2222-3333-4444-555566667777");
        private static readonly Guid Accom_Eta = Guid.Parse("1111aaaa-2222-bbbb-3333-444455556666");
        private static readonly Guid Accom_Theta = Guid.Parse("2222bbbb-3333-cccc-4444-555566667777");
        private static readonly Guid Accom_Iota = Guid.Parse("3333cccc-4444-dddd-5555-666677778888");
        private static readonly Guid Accom_Kappa = Guid.Parse("4444dddd-5555-eeee-6666-777788889999");

        // ===== Room Categories (10) =====
        private static readonly Guid RC_AlphaStd = Guid.Parse("12121212-3434-5656-7878-909090909090");
        private static readonly Guid RC_BetaDelx = Guid.Parse("23232323-4545-6767-8989-010101010101");
        private static readonly Guid RC_AlphaSup = Guid.Parse("32323232-5454-7676-9898-020202020202");
        private static readonly Guid RC_AlphaSuite = Guid.Parse("43434343-6565-8787-0909-030303030303");
        private static readonly Guid RC_BetaStd = Guid.Parse("54545454-7676-9898-1010-040404040404");
        private static readonly Guid RC_BetaFam = Guid.Parse("65656565-8787-0909-1111-050505050505");
        private static readonly Guid RC_GammaStd = Guid.Parse("76767676-9898-1010-1212-060606060606");
        private static readonly Guid RC_DeltaDelx = Guid.Parse("87878787-0909-1111-1313-070707070707");
        private static readonly Guid RC_EpsilonStd = Guid.Parse("98989898-1010-1212-1414-080808080808");
        private static readonly Guid RC_ZetaDelx = Guid.Parse("09090909-1111-1313-1515-090909090909");

        // ===== Rooms (10) =====
        private static readonly Guid Room_A101 = Guid.Parse("77777777-0000-0000-0000-000000000001");
        private static readonly Guid Room_B201 = Guid.Parse("77777777-0000-0000-0000-000000000002");
        private static readonly Guid Room_A102 = Guid.Parse("77777777-0000-0000-0000-000000000003");
        private static readonly Guid Room_A103 = Guid.Parse("77777777-0000-0000-0000-000000000004");
        private static readonly Guid Room_A104 = Guid.Parse("77777777-0000-0000-0000-000000000005");
        private static readonly Guid Room_B202 = Guid.Parse("77777777-0000-0000-0000-000000000006");
        private static readonly Guid Room_B203 = Guid.Parse("77777777-0000-0000-0000-000000000007");
        private static readonly Guid Room_G301 = Guid.Parse("77777777-0000-0000-0000-000000000008");
        private static readonly Guid Room_D401 = Guid.Parse("77777777-0000-0000-0000-000000000009");
        private static readonly Guid Room_E501 = Guid.Parse("77777777-0000-0000-0000-000000000010");

        // ===== Joins =====
        private static readonly Guid Join_RoomFac_1 = Guid.Parse("f1f1f1f1-1111-1111-1111-111111111111");
        private static readonly Guid Join_RoomFac_2 = Guid.Parse("f2f2f2f2-2222-2222-2222-222222222222");
        private static readonly Guid Join_RoomFac_3 = Guid.Parse("f3f3f3f3-3333-3333-3333-333333333333");
        private static readonly Guid Join_RoomFac_4 = Guid.Parse("f4f4f4f4-4444-4444-4444-444444444444");
        private static readonly Guid Join_RoomFac_5 = Guid.Parse("f5f5f5f5-5555-5555-5555-555555555555");
        private static readonly Guid Join_RoomFac_6 = Guid.Parse("f6f6f6f6-6666-6666-6666-666666666666");
        private static readonly Guid Join_RoomFac_7 = Guid.Parse("f7f7f7f7-7777-7777-7777-777777777777");
        private static readonly Guid Join_RoomFac_8 = Guid.Parse("f8f8f8f8-8888-8888-8888-888888888888");
        private static readonly Guid Join_RoomFac_9 = Guid.Parse("f9f9f9f9-9999-9999-9999-999999999999");
        private static readonly Guid Join_RoomFac_10 = Guid.Parse("fafafafa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        private static readonly Guid Join_RoomImg_1 = Guid.Parse("a1a1a1a1-1111-1111-1111-111111111111");
        private static readonly Guid Join_RoomImg_2 = Guid.Parse("a2a2a2a2-2222-2222-2222-222222222222");
        private static readonly Guid Join_RoomImg_3 = Guid.Parse("a3a3a3a3-3333-3333-3333-333333333333");
        private static readonly Guid Join_RoomImg_4 = Guid.Parse("a4a4a4a4-4444-4444-4444-444444444444");
        private static readonly Guid Join_RoomImg_5 = Guid.Parse("a5a5a5a5-5555-5555-5555-555555555555");
        private static readonly Guid Join_RoomImg_6 = Guid.Parse("a6a6a6a6-6666-6666-6666-666666666666");
        private static readonly Guid Join_RoomImg_7 = Guid.Parse("a7a7a7a7-7777-7777-7777-777777777777");
        private static readonly Guid Join_RoomImg_8 = Guid.Parse("a8a8a8a8-8888-8888-8888-888888888888");
        private static readonly Guid Join_RoomImg_9 = Guid.Parse("a9a9a9a9-9999-9999-9999-999999999999");
        private static readonly Guid Join_RoomImg_10 = Guid.Parse("abababab-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        private static readonly Guid Join_AccomFac_1 = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1");
        private static readonly Guid Join_AccomFac_2 = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2");
        private static readonly Guid Join_AccomFac_3 = Guid.Parse("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3");
        private static readonly Guid Join_AccomFac_4 = Guid.Parse("b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4");
        private static readonly Guid Join_AccomFac_5 = Guid.Parse("b5b5b5b5-b5b5-b5b5-b5b5-b5b5b5b5b5b5");
        private static readonly Guid Join_AccomFac_6 = Guid.Parse("b6b6b6b6-b6b6-b6b6-b6b6-b6b6b6b6b6b6");
        private static readonly Guid Join_AccomFac_7 = Guid.Parse("b7b7b7b7-b7b7-b7b7-b7b7-b7b7b7b7b7b7");
        private static readonly Guid Join_AccomFac_8 = Guid.Parse("b8b8b8b8-b8b8-b8b8-b8b8-b8b8b8b8b8b8");
        private static readonly Guid Join_AccomFac_9 = Guid.Parse("b9b9b9b9-b9b9-b9b9-b9b9-b9b9b9b9b9b9");
        private static readonly Guid Join_AccomFac_10 = Guid.Parse("babababa-baba-baba-baba-babababababa");

        private static readonly Guid Join_AccomImg_1 = Guid.Parse("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1");
        private static readonly Guid Join_AccomImg_2 = Guid.Parse("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2");
        private static readonly Guid Join_AccomImg_3 = Guid.Parse("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3");
        private static readonly Guid Join_AccomImg_4 = Guid.Parse("e4e4e4e4-e4e4-e4e4-e4e4-e4e4e4e4e4e4");
        private static readonly Guid Join_AccomImg_5 = Guid.Parse("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5");
        private static readonly Guid Join_AccomImg_6 = Guid.Parse("e6e6e6e6-e6e6-e6e6-e6e6-e6e6e6e6e6e6");
        private static readonly Guid Join_AccomImg_7 = Guid.Parse("e7e7e7e7-e7e7-e7e7-e7e7-e7e7e7e7e7e7");
        private static readonly Guid Join_AccomImg_8 = Guid.Parse("e8e8e8e8-e8e8-e8e8-e8e8-e8e8e8e8e8e8");
        private static readonly Guid Join_AccomImg_9 = Guid.Parse("e9e9e9e9-e9e9-e9e9-e9e9-e9e9e9e9e9e9");
        private static readonly Guid Join_AccomImg_10 = Guid.Parse("efefefef-efef-efef-efef-efefefefefef");

        private static readonly DateTime SeedNow = new DateTime(2025, 01, 01, 00, 00, 00, DateTimeKind.Utc);

        public static void Seed(this ModelBuilder b)
        {
            // ===== Loại chỗ ở =====
            b.Entity<AccomType>().HasData(
                new AccomType { Id = AccomType_Hotel, Type = "Khách sạn", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Resort, Type = "Khu nghỉ dưỡng", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Apartment, Type = "Căn hộ", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Villa, Type = "Biệt thự", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Hostel, Type = "Hostel", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Guesthouse, Type = "Nhà khách", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Homestay, Type = "Homestay", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Motel, Type = "Nhà nghỉ", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Capsule, Type = "Khách sạn con nhộng", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Bungalow, Type = "Bungalow", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Farmstay, Type = "Farmstay", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Campsite, Type = "Khu cắm trại", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Lodge, Type = "Nhà nghỉ Lodge", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Ryokan, Type = "Ryokan", CreatedAt = SeedNow },
                new AccomType { Id = AccomType_Riad, Type = "Riad", CreatedAt = SeedNow }
            );

            // ===== Tiện nghi =====
            b.Entity<Facility>().HasData(
                new Facility { Id = Facility_Wifi, Name = "Wi-Fi miễn phí", Icon = "wifi", CreatedAt = SeedNow },
                new Facility { Id = Facility_Pool, Name = "Hồ bơi", Icon = "pool", CreatedAt = SeedNow },
                new Facility { Id = Facility_Gym, Name = "Phòng gym", Icon = "dumbbell", CreatedAt = SeedNow },
                new Facility { Id = Facility_Spa, Name = "Spa", Icon = "spa", CreatedAt = SeedNow },
                new Facility { Id = Facility_Parking, Name = "Bãi đỗ xe", Icon = "parking", CreatedAt = SeedNow },
                new Facility { Id = Facility_Restaurant, Name = "Nhà hàng", Icon = "restaurant", CreatedAt = SeedNow },
                new Facility { Id = Facility_Bar, Name = "Bar", Icon = "glass", CreatedAt = SeedNow },
                new Facility { Id = Facility_Shuttle, Name = "Đưa đón sân bay", Icon = "bus", CreatedAt = SeedNow },
                new Facility { Id = Facility_Reception, Name = "Lễ tân 24/7", Icon = "bell", CreatedAt = SeedNow },
                new Facility { Id = Facility_Laundry, Name = "Giặt là", Icon = "washing", CreatedAt = SeedNow }
            );

            // ===== Loại giường =====
            b.Entity<BedType>().HasData(
                new BedType { Id = BedType_Queen, Type = "Giường Queen", CreatedAt = SeedNow },
                new BedType { Id = BedType_Twin, Type = "Giường Twin", CreatedAt = SeedNow },
                new BedType { Id = BedType_Single, Type = "Giường đơn", CreatedAt = SeedNow },
                new BedType { Id = BedType_Double, Type = "Giường đôi", CreatedAt = SeedNow },
                new BedType { Id = BedType_King, Type = "Giường King", CreatedAt = SeedNow },
                new BedType { Id = BedType_SuperKing, Type = "Giường Super King", CreatedAt = SeedNow },
                new BedType { Id = BedType_Bunk, Type = "Giường tầng", CreatedAt = SeedNow },
                new BedType { Id = BedType_SofaBed, Type = "Giường sofa", CreatedAt = SeedNow },
                new BedType { Id = BedType_Futon, Type = "Đệm futon", CreatedAt = SeedNow },
                new BedType { Id = BedType_Tatami, Type = "Đệm tatami", CreatedAt = SeedNow }
            );

            // ===== Chính sách huỷ =====
            b.Entity<CancelPolicy>().HasData(
                new CancelPolicy { Id = CancelPolicy_Flex, Type = "Linh hoạt (24h)", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_48h, Type = "Linh hoạt (48h)", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_72h, Type = "Linh hoạt (72h)", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_7d, Type = "Linh hoạt (7 ngày)", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_14d, Type = "Linh hoạt (14 ngày)", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_NonRefund, Type = "Không hoàn huỷ", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_NoShow1Night, Type = "Vắng mặt tính phí 1 đêm", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_FreeUntil18h, Type = "Miễn phí tới 18:00", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_SemiFlex, Type = "Bán linh hoạt", CreatedAt = SeedNow },
                new CancelPolicy { Id = CancelPolicy_SuperFlex, Type = "Siêu linh hoạt", CreatedAt = SeedNow }
            );

            // ===== Ảnh =====
            b.Entity<Image>().HasData(
                new Image { Id = Img_1, Url = "https://picsum.photos/id/1018/600/400", Alt = "Sảnh", CreatedAt = SeedNow },
                new Image { Id = Img_2, Url = "https://picsum.photos/id/1015/600/400", Alt = "Phòng ngủ", CreatedAt = SeedNow },
                new Image { Id = Img_3, Url = "https://picsum.photos/id/1025/600/400", Alt = "Phòng tiêu chuẩn", CreatedAt = SeedNow },
                new Image { Id = Img_4, Url = "https://picsum.photos/id/1039/600/400", Alt = "Deluxe hướng biển", CreatedAt = SeedNow },
                new Image { Id = Img_5, Url = "https://picsum.photos/id/1040/600/400", Alt = "Phòng khách suite", CreatedAt = SeedNow },
                new Image { Id = Img_6, Url = "https://picsum.photos/id/1041/600/400", Alt = "Phòng tắm", CreatedAt = SeedNow },
                new Image { Id = Img_7, Url = "https://picsum.photos/id/1042/600/400", Alt = "Bữa sáng", CreatedAt = SeedNow },
                new Image { Id = Img_8, Url = "https://picsum.photos/id/1043/600/400", Alt = "Hồ bơi", CreatedAt = SeedNow },
                new Image { Id = Img_9, Url = "https://picsum.photos/id/1044/600/400", Alt = "Khu gym", CreatedAt = SeedNow },
                new Image { Id = Img_10, Url = "https://picsum.photos/id/1045/600/400", Alt = "Khu spa", CreatedAt = SeedNow }
            );

            // ===== Phương thức thanh toán =====
            b.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = Pay_Cash, Name = "Tiền mặt" },
                new PaymentMethod { Id = Pay_CreditCard, Name = "Thẻ tín dụng (Visa/Master)" },
                new PaymentMethod { Id = Pay_DebitCard, Name = "Thẻ ghi nợ" },
                new PaymentMethod { Id = Pay_Momo, Name = "MoMo" },
                new PaymentMethod { Id = Pay_ZaloPay, Name = "ZaloPay" },
                new PaymentMethod { Id = Pay_BankTransfer, Name = "Chuyển khoản ngân hàng" },
                new PaymentMethod { Id = Pay_ApplePay, Name = "Apple Pay" },
                new PaymentMethod { Id = Pay_GooglePay, Name = "Google Pay" },
                new PaymentMethod { Id = Pay_VNPay, Name = "VNPAY" },
                new PaymentMethod { Id = Pay_PayPal, Name = "PayPal" }
            );

            // ===== Chỗ ở =====
            b.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    Id = Accom_Alpha,
                    Name = "Khách sạn Alpha",
                    Email = "contact@alpha.example",
                    Phone = "+84 123 456 789",
                    AccomTypeId = AccomType_Hotel,
                    Star = 4,
                    Rating = 8.6f,
                    Address = "01 Nguyễn Huệ, Q.1, TP. Hồ Chí Minh",
                    Location = "TP. Hồ Chí Minh",
                    GgMapsQuery = "Khach+san+Alpha+TP+Ho+Chi+Minh",
                    Ll = "10.776,106.700",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Beta,
                    Name = "Khu nghỉ dưỡng Beta",
                    Email = "hello@beta.example",
                    Phone = "+84 987 654 321",
                    AccomTypeId = AccomType_Resort,
                    Star = 5,
                    Rating = 9.1f,
                    Address = "Đường ven biển, Nha Trang",
                    Location = "Nha Trang",
                    GgMapsQuery = "Khu+nghi+duong+Beta+Nha+Trang",
                    Ll = "12.245,109.195",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Gamma,
                    Name = "Căn hộ Gamma",
                    Email = "stay@gamma.example",
                    Phone = "+84 909 111 222",
                    AccomTypeId = AccomType_Apartment,
                    Star = 4,
                    Rating = 8.2f,
                    Address = "Nguyễn Văn Linh, Đà Nẵng",
                    Location = "Đà Nẵng",
                    GgMapsQuery = "Can+ho+Gamma+Da+Nang",
                    Ll = "16.047,108.206",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Delta,
                    Name = "Biệt thự Delta",
                    Email = "booking@delta.example",
                    Phone = "+84 909 333 444",
                    AccomTypeId = AccomType_Villa,
                    Star = 5,
                    Rating = 9.0f,
                    Address = "Bãi biển An Bàng, Hội An",
                    Location = "Hội An",
                    GgMapsQuery = "Biet+thu+Delta+Hoi+An",
                    Ll = "15.879,108.335",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Epsilon,
                    Name = "Hostel Epsilon",
                    Email = "hi@epsilon.example",
                    Phone = "+84 909 555 666",
                    AccomTypeId = AccomType_Hostel,
                    Star = 3,
                    Rating = 8.0f,
                    Address = "Phố Cổ, Hà Nội",
                    Location = "Hà Nội",
                    GgMapsQuery = "Hostel+Epsilon+Ha+Noi",
                    Ll = "21.028,105.854",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Zeta,
                    Name = "Homestay Zeta",
                    Email = "hello@zeta.example",
                    Phone = "+84 909 777 888",
                    AccomTypeId = AccomType_Homestay,
                    Star = 4,
                    Rating = 8.7f,
                    Address = "Dương Đông, Phú Quốc",
                    Location = "Phú Quốc",
                    GgMapsQuery = "Homestay+Zeta+Phu+Quoc",
                    Ll = "10.284,103.984",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Eta,
                    Name = "Capsule Eta",
                    Email = "stay@eta.example",
                    Phone = "+84 909 000 111",
                    AccomTypeId = AccomType_Capsule,
                    Star = 3,
                    Rating = 7.9f,
                    Address = "Q.3, TP. Hồ Chí Minh",
                    Location = "TP. Hồ Chí Minh",
                    GgMapsQuery = "Capsule+Eta+TP+Ho+Chi+Minh",
                    Ll = "10.781,106.696",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Theta,
                    Name = "Lodge Theta",
                    Email = "stay@theta.example",
                    Phone = "+84 909 222 333",
                    AccomTypeId = AccomType_Lodge,
                    Star = 4,
                    Rating = 8.3f,
                    Address = "Thị trấn Sa Pa, Lào Cai",
                    Location = "Sa Pa",
                    GgMapsQuery = "Lodge+Theta+Sa+Pa",
                    Ll = "22.335,103.843",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Iota,
                    Name = "Ryokan Iota",
                    Email = "info@iota.example",
                    Phone = "+84 909 444 555",
                    AccomTypeId = AccomType_Ryokan,
                    Star = 5,
                    Rating = 9.2f,
                    Address = "Trung tâm Đà Lạt, Lâm Đồng",
                    Location = "Đà Lạt",
                    GgMapsQuery = "Ryokan+Iota+Da+Lat",
                    Ll = "11.940,108.458",
                    CreatedAt = SeedNow
                },
                new Accommodation
                {
                    Id = Accom_Kappa,
                    Name = "Farmstay Kappa",
                    Email = "farm@kappa.example",
                    Phone = "+84 909 666 777",
                    AccomTypeId = AccomType_Farmstay,
                    Star = 4,
                    Rating = 8.4f,
                    Address = "TP. Buôn Ma Thuột, Đắk Lắk",
                    Location = "Đắk Lắk",
                    GgMapsQuery = "Farmstay+Kappa+Dak+Lak",
                    Ll = "12.667,108.037",
                    CreatedAt = SeedNow
                }
            );

            // ===== Hạng phòng =====
            b.Entity<RoomCategory>().HasData(
                new RoomCategory { Id = RC_AlphaStd, Name = "Tiêu chuẩn", AccomId = Accom_Alpha, About = "Phòng 20m² ấm cúng", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_BetaDelx, Name = "Deluxe Hướng Biển", AccomId = Accom_Beta, About = "Phòng 32m², có ban công", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_AlphaSup, Name = "Superior", AccomId = Accom_Alpha, About = "22m², có cửa sổ", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_AlphaSuite, Name = "Suite", AccomId = Accom_Alpha, About = "45m², có góc tiếp khách", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_BetaStd, Name = "Tiêu chuẩn", AccomId = Accom_Beta, About = "24m²", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_BetaFam, Name = "Gia đình", AccomId = Accom_Beta, About = "35m², 2 giường", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_GammaStd, Name = "Studio", AccomId = Accom_Gamma, About = "28m², bếp nhỏ", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_DeltaDelx, Name = "Grand Deluxe", AccomId = Accom_Delta, About = "40m², nhìn vườn", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_EpsilonStd, Name = "Ký túc xá", AccomId = Accom_Epsilon, About = "Giường tầng, phòng chung", CreatedAt = SeedNow },
                new RoomCategory { Id = RC_ZetaDelx, Name = "Premier", AccomId = Accom_Zeta, About = "29m², có ban công", CreatedAt = SeedNow }
            );

            // ===== Phòng =====
            b.Entity<Room>().HasData(
                new Room { Id = Room_A101, Name = "A-101", Breakfast = true, NumberOfBeds = 1, BedTypeId = BedType_Queen, CancelPolicyId = CancelPolicy_Flex, Available = true, CategoryId = RC_AlphaStd, Rating = 8.5f, CreatedAt = SeedNow, Price = 850000m },
                new Room { Id = Room_B201, Name = "B-201", Breakfast = true, NumberOfBeds = 2, BedTypeId = BedType_Twin, CancelPolicyId = CancelPolicy_Flex, Available = true, CategoryId = RC_BetaDelx, Rating = 9.2f, CreatedAt = SeedNow, Price = 1250000m },
                new Room { Id = Room_A102, Name = "A-102", Breakfast = false, NumberOfBeds = 1, BedTypeId = BedType_Single, CancelPolicyId = CancelPolicy_48h, Available = true, CategoryId = RC_AlphaStd, Rating = 8.1f, CreatedAt = SeedNow, Price = 780000m },
                new Room { Id = Room_A103, Name = "A-103", Breakfast = true, NumberOfBeds = 1, BedTypeId = BedType_Double, CancelPolicyId = CancelPolicy_72h, Available = true, CategoryId = RC_AlphaSup, Rating = 8.3f, CreatedAt = SeedNow, Price = 990000m },
                new Room { Id = Room_A104, Name = "A-104", Breakfast = true, NumberOfBeds = 2, BedTypeId = BedType_King, CancelPolicyId = CancelPolicy_7d, Available = true, CategoryId = RC_AlphaSuite, Rating = 8.9f, CreatedAt = SeedNow, Price = 1650000m },
                new Room { Id = Room_B202, Name = "B-202", Breakfast = false, NumberOfBeds = 1, BedTypeId = BedType_SuperKing, CancelPolicyId = CancelPolicy_14d, Available = true, CategoryId = RC_BetaStd, Rating = 8.7f, CreatedAt = SeedNow, Price = 880000m },
                new Room { Id = Room_B203, Name = "B-203", Breakfast = true, NumberOfBeds = 2, BedTypeId = BedType_Bunk, CancelPolicyId = CancelPolicy_NonRefund, Available = true, CategoryId = RC_BetaFam, Rating = 8.8f, CreatedAt = SeedNow, Price = 1120000m },
                new Room { Id = Room_G301, Name = "G-301", Breakfast = false, NumberOfBeds = 1, BedTypeId = BedType_SofaBed, CancelPolicyId = CancelPolicy_NoShow1Night, Available = true, CategoryId = RC_GammaStd, Rating = 8.0f, CreatedAt = SeedNow, Price = 720000m },
                new Room { Id = Room_D401, Name = "D-401", Breakfast = true, NumberOfBeds = 1, BedTypeId = BedType_Futon, CancelPolicyId = CancelPolicy_FreeUntil18h, Available = true, CategoryId = RC_DeltaDelx, Rating = 8.6f, CreatedAt = SeedNow, Price = 1320000m },
                new Room { Id = Room_E501, Name = "E-501", Breakfast = true, NumberOfBeds = 2, BedTypeId = BedType_Tatami, CancelPolicyId = CancelPolicy_SemiFlex, Available = true, CategoryId = RC_EpsilonStd, Rating = 8.2f, CreatedAt = SeedNow, Price = 980000m }
            );

            // ===== Join: Chỗ ở <-> Tiện nghi =====
            b.Entity<Accom_Facility>().HasData(
                new Accom_Facility { Id = Join_AccomFac_1, AccomId = Accom_Alpha, FacilityId = Facility_Wifi },
                new Accom_Facility { Id = Join_AccomFac_2, AccomId = Accom_Alpha, FacilityId = Facility_Pool },
                new Accom_Facility { Id = Join_AccomFac_3, AccomId = Accom_Beta, FacilityId = Facility_Wifi },
                new Accom_Facility { Id = Join_AccomFac_4, AccomId = Accom_Beta, FacilityId = Facility_Gym },
                new Accom_Facility { Id = Join_AccomFac_5, AccomId = Accom_Gamma, FacilityId = Facility_Parking },
                new Accom_Facility { Id = Join_AccomFac_6, AccomId = Accom_Delta, FacilityId = Facility_Spa },
                new Accom_Facility { Id = Join_AccomFac_7, AccomId = Accom_Epsilon, FacilityId = Facility_Reception },
                new Accom_Facility { Id = Join_AccomFac_8, AccomId = Accom_Zeta, FacilityId = Facility_Shuttle },
                new Accom_Facility { Id = Join_AccomFac_9, AccomId = Accom_Eta, FacilityId = Facility_Laundry },
                new Accom_Facility { Id = Join_AccomFac_10, AccomId = Accom_Theta, FacilityId = Facility_Restaurant }
            );

            // ===== Join: Chỗ ở <-> Ảnh =====
            b.Entity<Accom_Image>().HasData(
                new Accom_Image { Id = Join_AccomImg_1, AccomId = Accom_Alpha, ImageId = Img_1 },
                new Accom_Image { Id = Join_AccomImg_2, AccomId = Accom_Alpha, ImageId = Img_2 },
                new Accom_Image { Id = Join_AccomImg_3, AccomId = Accom_Beta, ImageId = Img_2 },
                new Accom_Image { Id = Join_AccomImg_4, AccomId = Accom_Beta, ImageId = Img_4 },
                new Accom_Image { Id = Join_AccomImg_5, AccomId = Accom_Gamma, ImageId = Img_5 },
                new Accom_Image { Id = Join_AccomImg_6, AccomId = Accom_Delta, ImageId = Img_6 },
                new Accom_Image { Id = Join_AccomImg_7, AccomId = Accom_Epsilon, ImageId = Img_7 },
                new Accom_Image { Id = Join_AccomImg_8, AccomId = Accom_Zeta, ImageId = Img_8 },
                new Accom_Image { Id = Join_AccomImg_9, AccomId = Accom_Eta, ImageId = Img_9 },
                new Accom_Image { Id = Join_AccomImg_10, AccomId = Accom_Theta, ImageId = Img_10 }
            );

            // ===== Join: Hạng phòng <-> Tiện nghi =====
            b.Entity<Room_Facility>().HasData(
                new Room_Facility { Id = Join_RoomFac_1, RoomCategoryId = RC_AlphaStd, FacilityId = Facility_Wifi },
                new Room_Facility { Id = Join_RoomFac_2, RoomCategoryId = RC_BetaDelx, FacilityId = Facility_Pool },
                new Room_Facility { Id = Join_RoomFac_3, RoomCategoryId = RC_AlphaSup, FacilityId = Facility_Reception },
                new Room_Facility { Id = Join_RoomFac_4, RoomCategoryId = RC_AlphaSuite, FacilityId = Facility_Spa },
                new Room_Facility { Id = Join_RoomFac_5, RoomCategoryId = RC_BetaStd, FacilityId = Facility_Parking },
                new Room_Facility { Id = Join_RoomFac_6, RoomCategoryId = RC_BetaFam, FacilityId = Facility_Laundry },
                new Room_Facility { Id = Join_RoomFac_7, RoomCategoryId = RC_GammaStd, FacilityId = Facility_Gym },
                new Room_Facility { Id = Join_RoomFac_8, RoomCategoryId = RC_DeltaDelx, FacilityId = Facility_Restaurant },
                new Room_Facility { Id = Join_RoomFac_9, RoomCategoryId = RC_EpsilonStd, FacilityId = Facility_Wifi },
                new Room_Facility { Id = Join_RoomFac_10, RoomCategoryId = RC_ZetaDelx, FacilityId = Facility_Bar }
            );

            // ===== Join: Hạng phòng <-> Ảnh =====
            b.Entity<Room_Image>().HasData(
                new Room_Image { Id = Join_RoomImg_1, RoomCategoryId = RC_AlphaStd, ImageId = Img_3 },
                new Room_Image { Id = Join_RoomImg_2, RoomCategoryId = RC_BetaDelx, ImageId = Img_4 },
                new Room_Image { Id = Join_RoomImg_3, RoomCategoryId = RC_AlphaSup, ImageId = Img_5 },
                new Room_Image { Id = Join_RoomImg_4, RoomCategoryId = RC_AlphaSuite, ImageId = Img_6 },
                new Room_Image { Id = Join_RoomImg_5, RoomCategoryId = RC_BetaStd, ImageId = Img_7 },
                new Room_Image { Id = Join_RoomImg_6, RoomCategoryId = RC_BetaFam, ImageId = Img_8 },
                new Room_Image { Id = Join_RoomImg_7, RoomCategoryId = RC_GammaStd, ImageId = Img_9 },
                new Room_Image { Id = Join_RoomImg_8, RoomCategoryId = RC_DeltaDelx, ImageId = Img_10 },
                new Room_Image { Id = Join_RoomImg_9, RoomCategoryId = RC_EpsilonStd, ImageId = Img_2 },
                new Room_Image { Id = Join_RoomImg_10, RoomCategoryId = RC_ZetaDelx, ImageId = Img_1 }
            );
        }
    }
}
