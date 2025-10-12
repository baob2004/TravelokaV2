using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"));

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Type",
                value: "Khách sạn");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Type",
                value: "Khu nghỉ dưỡng");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Type",
                value: "Căn hộ");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "Type",
                value: "Biệt thự");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "Type",
                value: "Nhà khách");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "Type",
                value: "Nhà nghỉ");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Type",
                value: "Khách sạn con nhộng");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "Type",
                value: "Khu cắm trại");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "Type",
                value: "Nhà nghỉ Lodge");

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03") }
                });

            migrationBuilder.InsertData(
                table: "Accom_Images",
                columns: new[] { "Id", "AccomId", "ImageId" },
                values: new object[] { new Guid("e4e4e4e4-e4e4-e4e4-e4e4-e4e4e4e4e4e4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000004") });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555566667777"),
                columns: new[] { "Address", "GgMapsQuery", "Location", "Name" },
                values: new object[] { "01 Nguyễn Huệ, Q.1, TP. Hồ Chí Minh", "Khach+san+Alpha+TP+Ho+Chi+Minh", "TP. Hồ Chí Minh", "Khách sạn Alpha" });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-2222-3333-4444-555566667777"),
                columns: new[] { "Address", "GgMapsQuery", "Name" },
                values: new object[] { "Đường ven biển, Nha Trang", "Khu+nghi+duong+Beta+Nha+Trang", "Khu nghỉ dưỡng Beta" });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "AccomTypeId", "Address", "CreatedAt", "DeletedAt", "DeletedBy", "Description", "Email", "GgMapsQuery", "IsDeleted", "Ll", "Location", "ModifyAt", "Name", "Phone", "Rating", "Star", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("99999999-9999-9999-9999-999999999999"), "Q.3, TP. Hồ Chí Minh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@eta.example", "Capsule+Eta+TP+Ho+Chi+Minh", false, "10.781,106.696", "TP. Hồ Chí Minh", null, "Capsule Eta", "+84 909 000 111", 7.9f, 3, null },
                    { new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Thị trấn Sa Pa, Lào Cai", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@theta.example", "Lodge+Theta+Sa+Pa", false, "22.335,103.843", "Sa Pa", null, "Lodge Theta", "+84 909 222 333", 8.3f, 4, null },
                    { new Guid("3333cccc-4444-dddd-5555-666677778888"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Trung tâm Đà Lạt, Lâm Đồng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "info@iota.example", "Ryokan+Iota+Da+Lat", false, "11.940,108.458", "Đà Lạt", null, "Ryokan Iota", "+84 909 444 555", 9.2f, 5, null },
                    { new Guid("4444dddd-5555-eeee-6666-777788889999"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "TP. Buôn Ma Thuột, Đắk Lắk", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "farm@kappa.example", "Farmstay+Kappa+Dak+Lak", false, "12.667,108.037", "Đắk Lắk", null, "Farmstay Kappa", "+84 909 666 777", 8.4f, 4, null },
                    { new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("33333333-3333-3333-3333-333333333333"), "Nguyễn Văn Linh, Đà Nẵng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "stay@gamma.example", "Can+ho+Gamma+Da+Nang", false, "16.047,108.206", "Đà Nẵng", null, "Căn hộ Gamma", "+84 909 111 222", 8.2f, 4, null },
                    { new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("44444444-4444-4444-4444-444444444444"), "Bãi biển An Bàng, Hội An", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "booking@delta.example", "Biet+thu+Delta+Hoi+An", false, "15.879,108.335", "Hội An", null, "Biệt thự Delta", "+84 909 333 444", 9f, 5, null },
                    { new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("55555555-5555-5555-5555-555555555555"), "Phố Cổ, Hà Nội", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hi@epsilon.example", "Hostel+Epsilon+Ha+Noi", false, "21.028,105.854", "Hà Nội", null, "Hostel Epsilon", "+84 909 555 666", 8f, 3, null },
                    { new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("77777777-7777-7777-7777-777777777777"), "Dương Đông, Phú Quốc", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, "hello@zeta.example", "Homestay+Zeta+Phu+Quoc", false, "10.284,103.984", "Phú Quốc", null, "Homestay Zeta", "+84 909 777 888", 8.7f, 4, null }
                });

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddd04"),
                column: "Type",
                value: "Giường Queen");

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee05"),
                column: "Type",
                value: "Giường Twin");

            migrationBuilder.InsertData(
                table: "BedTypes",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("bead0000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường đơn", null },
                    { new Guid("bead0000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường đôi", null },
                    { new Guid("bead0000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường King", null },
                    { new Guid("bead0000-0000-0000-0000-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường Super King", null },
                    { new Guid("bead0000-0000-0000-0000-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường tầng", null },
                    { new Guid("bead0000-0000-0000-0000-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Giường sofa", null },
                    { new Guid("bead0000-0000-0000-0000-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Đệm futon", null },
                    { new Guid("bead0000-0000-0000-0000-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Đệm tatami", null }
                });

            migrationBuilder.UpdateData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"),
                column: "Type",
                value: "Linh hoạt (24h)");

            migrationBuilder.InsertData(
                table: "CancelPolicies",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("cafe0000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (48h)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (72h)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (7 ngày)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Linh hoạt (14 ngày)", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Không hoàn huỷ", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Vắng mặt tính phí 1 đêm", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Miễn phí tới 18:00", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Bán linh hoạt", null },
                    { new Guid("cafe0000-0000-0000-0000-000000000009"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Siêu linh hoạt", null }
                });

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                column: "Name",
                value: "Wi-Fi miễn phí");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02"),
                column: "Name",
                value: "Hồ bơi");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03"),
                column: "Name",
                value: "Phòng gym");

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedAt", "Icon", "ModifyAt", "Name", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "spa", null, "Spa", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "parking", null, "Bãi đỗ xe", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "restaurant", null, "Nhà hàng", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "glass", null, "Bar", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bus", null, "Đưa đón sân bay", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "bell", null, "Lễ tân 24/7", null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "washing", null, "Giặt là", null }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000001"),
                column: "Alt",
                value: "Sảnh");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000002"),
                column: "Alt",
                value: "Phòng ngủ");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000003"),
                column: "Alt",
                value: "Phòng tiêu chuẩn");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000004"),
                column: "Alt",
                value: "Deluxe hướng biển");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ModifyAt", "UpdateBy", "Url" },
                values: new object[,]
                {
                    { new Guid("99999999-0000-0000-0000-000000000005"), "Phòng khách suite", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1040/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000006"), "Phòng tắm", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1041/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000007"), "Bữa sáng", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1042/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000008"), "Hồ bơi", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1043/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000009"), "Khu gym", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1044/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000010"), "Khu spa", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1045/600/400" }
                });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("11112222-3333-4444-5555-666677778888"),
                column: "Name",
                value: "Tiền mặt");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("22223333-4444-5555-6666-777788889999"),
                column: "Name",
                value: "Thẻ tín dụng (Visa/Master)");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("33334444-5555-6666-7777-88889999aaaa"),
                column: "Name",
                value: "Thẻ ghi nợ");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("66667777-8888-9999-aaaa-bbbbccccdddd"),
                column: "Name",
                value: "Chuyển khoản ngân hàng");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("77778888-9999-aaaa-bbbb-ccccddddeeee"), "Apple Pay" },
                    { new Guid("88889999-aaaa-bbbb-cccc-ddddeeeeffff"), "Google Pay" },
                    { new Guid("9999aaaa-bbbb-cccc-dddd-eeeeffff0000"), "VNPAY" },
                    { new Guid("aaaa9999-bbbb-cccc-dddd-eeeeffff1111"), "PayPal" }
                });

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("12121212-3434-5656-7878-909090909090"),
                columns: new[] { "About", "Name" },
                values: new object[] { "Phòng 20m² ấm cúng", "Tiêu chuẩn" });

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("23232323-4545-6767-8989-010101010101"),
                columns: new[] { "About", "Name" },
                values: new object[] { "Phòng 32m², có ban công", "Deluxe Hướng Biển" });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "About", "AccomId", "AccommodationId", "BasicFacilities", "BathAmenities", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "RoomFacilities", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("32323232-5454-7676-9898-020202020202"), "22m², có cửa sổ", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Superior", "[]", null },
                    { new Guid("43434343-6565-8787-0909-030303030303"), "45m², có góc tiếp khách", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Suite", "[]", null },
                    { new Guid("54545454-7676-9898-1010-040404040404"), "24m²", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Tiêu chuẩn", "[]", null },
                    { new Guid("65656565-8787-0909-1111-050505050505"), "35m², 2 giường", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Gia đình", "[]", null }
                });

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("b5b5b5b5-b5b5-b5b5-b5b5-b5b5b5b5b5b5"), new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05") },
                    { new Guid("b6b6b6b6-b6b6-b6b6-b6b6-b6b6b6b6b6b6"), new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04") },
                    { new Guid("b7b7b7b7-b7b7-b7b7-b7b7-b7b7b7b7b7b7"), new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09") },
                    { new Guid("b8b8b8b8-b8b8-b8b8-b8b8-b8b8b8b8b8b8"), new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08") },
                    { new Guid("b9b9b9b9-b9b9-b9b9-b9b9-b9b9b9b9b9b9"), new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { new Guid("babababa-baba-baba-baba-babababababa"), new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06") }
                });

            migrationBuilder.InsertData(
                table: "Accom_Images",
                columns: new[] { "Id", "AccomId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"), new Guid("cccc1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000005") },
                    { new Guid("e6e6e6e6-e6e6-e6e6-e6e6-e6e6e6e6e6e6"), new Guid("dddd1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000006") },
                    { new Guid("e7e7e7e7-e7e7-e7e7-e7e7-e7e7e7e7e7e7"), new Guid("eeee1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000007") },
                    { new Guid("e8e8e8e8-e8e8-e8e8-e8e8-e8e8e8e8e8e8"), new Guid("ffff1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000008") },
                    { new Guid("e9e9e9e9-e9e9-e9e9-e9e9-e9e9e9e9e9e9"), new Guid("1111aaaa-2222-bbbb-3333-444455556666"), new Guid("99999999-0000-0000-0000-000000000009") },
                    { new Guid("efefefef-efef-efef-efef-efefefefefef"), new Guid("2222bbbb-3333-cccc-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000010") }
                });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "About", "AccomId", "AccommodationId", "BasicFacilities", "BathAmenities", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "RoomFacilities", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("09090909-1111-1313-1515-090909090909"), "29m², có ban công", new Guid("ffff1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Premier", "[]", null },
                    { new Guid("76767676-9898-1010-1212-060606060606"), "28m², bếp nhỏ", new Guid("cccc1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Studio", "[]", null },
                    { new Guid("87878787-0909-1111-1313-070707070707"), "40m², nhìn vườn", new Guid("dddd1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Grand Deluxe", "[]", null },
                    { new Guid("98989898-1010-1212-1414-080808080808"), "Giường tầng, phòng chung", new Guid("eeee1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "Ký túc xá", "[]", null }
                });

            migrationBuilder.InsertData(
                table: "Room_Facilities",
                columns: new[] { "Id", "FacilityId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("f3f3f3f3-3333-3333-3333-333333333333"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09"), new Guid("32323232-5454-7676-9898-020202020202") },
                    { new Guid("f4f4f4f4-4444-4444-4444-444444444444"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04"), new Guid("43434343-6565-8787-0909-030303030303") },
                    { new Guid("f5f5f5f5-5555-5555-5555-555555555555"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05"), new Guid("54545454-7676-9898-1010-040404040404") },
                    { new Guid("f6f6f6f6-6666-6666-6666-666666666666"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), new Guid("65656565-8787-0909-1111-050505050505") }
                });

            migrationBuilder.InsertData(
                table: "Room_Images",
                columns: new[] { "Id", "ImageId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("a3a3a3a3-3333-3333-3333-333333333333"), new Guid("99999999-0000-0000-0000-000000000005"), new Guid("32323232-5454-7676-9898-020202020202") },
                    { new Guid("a4a4a4a4-4444-4444-4444-444444444444"), new Guid("99999999-0000-0000-0000-000000000006"), new Guid("43434343-6565-8787-0909-030303030303") },
                    { new Guid("a5a5a5a5-5555-5555-5555-555555555555"), new Guid("99999999-0000-0000-0000-000000000007"), new Guid("54545454-7676-9898-1010-040404040404") },
                    { new Guid("a6a6a6a6-6666-6666-6666-666666666666"), new Guid("99999999-0000-0000-0000-000000000008"), new Guid("65656565-8787-0909-1111-050505050505") }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedTypeId", "Breakfast", "CancelPolicyId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "NumberOfBeds", "Rating", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("77777777-0000-0000-0000-000000000003"), true, new Guid("bead0000-0000-0000-0000-000000000001"), false, new Guid("cafe0000-0000-0000-0000-000000000001"), new Guid("12121212-3434-5656-7878-909090909090"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-102", 1, 8.1f, null },
                    { new Guid("77777777-0000-0000-0000-000000000004"), true, new Guid("bead0000-0000-0000-0000-000000000002"), true, new Guid("cafe0000-0000-0000-0000-000000000002"), new Guid("32323232-5454-7676-9898-020202020202"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-103", 1, 8.3f, null },
                    { new Guid("77777777-0000-0000-0000-000000000005"), true, new Guid("bead0000-0000-0000-0000-000000000003"), true, new Guid("cafe0000-0000-0000-0000-000000000003"), new Guid("43434343-6565-8787-0909-030303030303"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "A-104", 2, 8.9f, null },
                    { new Guid("77777777-0000-0000-0000-000000000006"), true, new Guid("bead0000-0000-0000-0000-000000000004"), false, new Guid("cafe0000-0000-0000-0000-000000000004"), new Guid("54545454-7676-9898-1010-040404040404"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-202", 1, 8.7f, null },
                    { new Guid("77777777-0000-0000-0000-000000000007"), true, new Guid("bead0000-0000-0000-0000-000000000005"), true, new Guid("cafe0000-0000-0000-0000-000000000005"), new Guid("65656565-8787-0909-1111-050505050505"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "B-203", 2, 8.8f, null }
                });

            migrationBuilder.InsertData(
                table: "Room_Facilities",
                columns: new[] { "Id", "FacilityId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("f7f7f7f7-7777-7777-7777-777777777777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03"), new Guid("76767676-9898-1010-1212-060606060606") },
                    { new Guid("f8f8f8f8-8888-8888-8888-888888888888"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06"), new Guid("87878787-0909-1111-1313-070707070707") },
                    { new Guid("f9f9f9f9-9999-9999-9999-999999999999"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"), new Guid("98989898-1010-1212-1414-080808080808") },
                    { new Guid("fafafafa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07"), new Guid("09090909-1111-1313-1515-090909090909") }
                });

            migrationBuilder.InsertData(
                table: "Room_Images",
                columns: new[] { "Id", "ImageId", "RoomCategoryId" },
                values: new object[,]
                {
                    { new Guid("a7a7a7a7-7777-7777-7777-777777777777"), new Guid("99999999-0000-0000-0000-000000000009"), new Guid("76767676-9898-1010-1212-060606060606") },
                    { new Guid("a8a8a8a8-8888-8888-8888-888888888888"), new Guid("99999999-0000-0000-0000-000000000010"), new Guid("87878787-0909-1111-1313-070707070707") },
                    { new Guid("a9a9a9a9-9999-9999-9999-999999999999"), new Guid("99999999-0000-0000-0000-000000000002"), new Guid("98989898-1010-1212-1414-080808080808") },
                    { new Guid("abababab-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("99999999-0000-0000-0000-000000000001"), new Guid("09090909-1111-1313-1515-090909090909") }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedTypeId", "Breakfast", "CancelPolicyId", "CategoryId", "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted", "ModifyAt", "Name", "NumberOfBeds", "Rating", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("77777777-0000-0000-0000-000000000008"), true, new Guid("bead0000-0000-0000-0000-000000000006"), false, new Guid("cafe0000-0000-0000-0000-000000000006"), new Guid("76767676-9898-1010-1212-060606060606"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "G-301", 1, 8f, null },
                    { new Guid("77777777-0000-0000-0000-000000000009"), true, new Guid("bead0000-0000-0000-0000-000000000007"), true, new Guid("cafe0000-0000-0000-0000-000000000007"), new Guid("87878787-0909-1111-1313-070707070707"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "D-401", 1, 8.6f, null },
                    { new Guid("77777777-0000-0000-0000-000000000010"), true, new Guid("bead0000-0000-0000-0000-000000000008"), true, new Guid("cafe0000-0000-0000-0000-000000000008"), new Guid("98989898-1010-1212-1414-080808080808"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "E-501", 2, 8.2f, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b4b4b4b4-b4b4-b4b4-b4b4-b4b4b4b4b4b4"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b5b5b5b5-b5b5-b5b5-b5b5-b5b5b5b5b5b5"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b6b6b6b6-b6b6-b6b6-b6b6-b6b6b6b6b6b6"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b7b7b7b7-b7b7-b7b7-b7b7-b7b7b7b7b7b7"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b8b8b8b8-b8b8-b8b8-b8b8-b8b8b8b8b8b8"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b9b9b9b9-b9b9-b9b9-b9b9-b9b9b9b9b9b9"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("babababa-baba-baba-baba-babababababa"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e4e4e4e4-e4e4-e4e4-e4e4-e4e4e4e4e4e4"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e6e6e6e6-e6e6-e6e6-e6e6-e6e6e6e6e6e6"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e7e7e7e7-e7e7-e7e7-e7e7-e7e7e7e7e7e7"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e8e8e8e8-e8e8-e8e8-e8e8-e8e8e8e8e8e8"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e9e9e9e9-e9e9-e9e9-e9e9-e9e9e9e9e9e9"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("efefefef-efef-efef-efef-efefefefefef"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("3333cccc-4444-dddd-5555-666677778888"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("4444dddd-5555-eeee-6666-777788889999"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("77778888-9999-aaaa-bbbb-ccccddddeeee"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("88889999-aaaa-bbbb-cccc-ddddeeeeffff"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("9999aaaa-bbbb-cccc-dddd-eeeeffff0000"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("aaaa9999-bbbb-cccc-dddd-eeeeffff1111"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f3f3f3f3-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f4f4f4f4-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f5f5f5f5-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f6f6f6f6-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f7f7f7f7-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f8f8f8f8-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f9f9f9f9-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Room_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("fafafafa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a3a3a3a3-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a4a4a4a4-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a5a5a5a5-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a6a6a6a6-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a7a7a7a7-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a8a8a8a8-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("a9a9a9a9-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Room_Images",
                keyColumn: "Id",
                keyValue: new Guid("abababab-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("1111aaaa-2222-bbbb-3333-444455556666"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("2222bbbb-3333-cccc-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("bead0000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cafe0000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa04"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa05"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa06"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa07"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa08"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa09"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("09090909-1111-1313-1515-090909090909"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("32323232-5454-7676-9898-020202020202"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("43434343-6565-8787-0909-030303030303"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("54545454-7676-9898-1010-040404040404"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("65656565-8787-0909-1111-050505050505"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("76767676-9898-1010-1212-060606060606"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("87878787-0909-1111-1313-070707070707"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("98989898-1010-1212-1414-080808080808"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("dddd1111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("eeee1111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("ffff1111-2222-3333-4444-555566667777"));

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Type",
                value: "Hotel");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Type",
                value: "Resort");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Type",
                value: "Apartment");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "Type",
                value: "Villa");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "Type",
                value: "Guesthouse");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "Type",
                value: "Motel");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "Type",
                value: "Capsule");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "Type",
                value: "Campsite");

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "Type",
                value: "Lodge");

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01") },
                    { new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03") }
                });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555566667777"),
                columns: new[] { "Address", "GgMapsQuery", "Location", "Name" },
                values: new object[] { "01 Main St, District 1, HCMC", "Alpha+Hotel+HCMC", "Ho Chi Minh City", "Alpha Hotel" });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-2222-3333-4444-555566667777"),
                columns: new[] { "Address", "GgMapsQuery", "Name" },
                values: new object[] { "Beach Rd, Nha Trang", "Beta+Resort+Nha+Trang", "Beta Resort" });

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddd04"),
                column: "Type",
                value: "Queen");

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeee05"),
                column: "Type",
                value: "Twin");

            migrationBuilder.UpdateData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"),
                column: "Type",
                value: "Flexible (24h)");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                column: "Name",
                value: "Free Wi-Fi");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbb02"),
                column: "Name",
                value: "Pool");

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccc03"),
                column: "Name",
                value: "Gym");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000001"),
                column: "Alt",
                value: "Lobby");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000002"),
                column: "Alt",
                value: "Room");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000003"),
                column: "Alt",
                value: "Standard room");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000004"),
                column: "Alt",
                value: "Deluxe sea view");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("11112222-3333-4444-5555-666677778888"),
                column: "Name",
                value: "Cash");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("22223333-4444-5555-6666-777788889999"),
                column: "Name",
                value: "Credit Card (Visa/Master)");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("33334444-5555-6666-7777-88889999aaaa"),
                column: "Name",
                value: "Debit Card");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("66667777-8888-9999-aaaa-bbbbccccdddd"),
                column: "Name",
                value: "Bank Transfer");

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("12121212-3434-5656-7878-909090909090"),
                columns: new[] { "About", "Name" },
                values: new object[] { "Cozy 20m2", "Standard" });

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("23232323-4545-6767-8989-010101010101"),
                columns: new[] { "About", "Name" },
                values: new object[] { "Spacious 32m2, balcony", "Deluxe Sea View" });
        }
    }
}
