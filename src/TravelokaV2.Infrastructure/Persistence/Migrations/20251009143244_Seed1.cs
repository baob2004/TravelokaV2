using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccomTypes",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Hotel", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Resort", null }
                });

            migrationBuilder.InsertData(
                table: "BedTypes",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Queen", null },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Twin", null }
                });

            migrationBuilder.InsertData(
                table: "CancelPolicies",
                columns: new[] { "Id", "CreatedAt", "ModifyAt", "Type", "UpdateBy" },
                values: new object[] { new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Flexible (24h)", null });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedAt", "Icon", "ModifyAt", "Name", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "wifi", null, "Free Wi-Fi", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "pool", null, "Pool", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dumbbell", null, "Gym", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "CreatedAt", "ModifyAt", "UpdateBy", "Url" },
                values: new object[,]
                {
                    { new Guid("99999999-0000-0000-0000-000000000001"), "Lobby", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1018/600/400" },
                    { new Guid("99999999-0000-0000-0000-000000000002"), "Room", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "https://picsum.photos/id/1015/600/400" }
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "AccomTypeId", "Address", "CreatedAt", "Description", "Email", "GgMapsQuery", "Ll", "Location", "ModifyAt", "Name", "Phone", "Rating", "Star", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("11111111-1111-1111-1111-111111111111"), "01 Main St, District 1, HCMC", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "contact@alpha.example", "Alpha+Hotel+HCMC", "10.776,106.700", "Ho Chi Minh City", null, "Alpha Hotel", "+84 123 456 789", 8.6f, 4, null },
                    { new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("22222222-2222-2222-2222-222222222222"), "Beach Rd, Nha Trang", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "hello@beta.example", "Beta+Resort+Nha+Trang", "12.245,109.195", "Nha Trang", null, "Beta Resort", "+84 987 654 321", 9.1f, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Available", "BedTypeId", "Breakfast", "CancelPolicyId", "CategoryId", "CreatedAt", "ModifyAt", "Name", "NumberOfBeds", "Rating", "RoomCategoryId", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("77777777-0000-0000-0000-000000000001"), true, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("12121212-3434-5656-7878-909090909090"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "A-101", 1, 8.5f, null, null },
                    { new Guid("77777777-0000-0000-0000-000000000002"), true, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), true, new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"), new Guid("23232323-4545-6767-8989-010101010101"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "B-201", 2, 9.2f, null, null }
                });

            migrationBuilder.InsertData(
                table: "Accom_Facilities",
                columns: new[] { "Id", "AccomId", "FacilityId" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") }
                });

            migrationBuilder.InsertData(
                table: "Accom_Images",
                columns: new[] { "Id", "AccomId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000001") },
                    { new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"), new Guid("aaaa1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") },
                    { new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"), new Guid("bbbb1111-2222-3333-4444-555566667777"), new Guid("99999999-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "RoomCategories",
                columns: new[] { "Id", "About", "AccomId", "AccommodationId", "BasicFacilities", "BathAmenities", "CreatedAt", "ModifyAt", "Name", "RoomFacilities", "UpdateBy" },
                values: new object[,]
                {
                    { new Guid("12121212-3434-5656-7878-909090909090"), "Cozy 20m2", new Guid("aaaa1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Standard", "[]", null },
                    { new Guid("23232323-4545-6767-8989-010101010101"), "Spacious 32m2, balcony", new Guid("bbbb1111-2222-3333-4444-555566667777"), null, "[]", "[]", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "Deluxe Sea View", "[]", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3"));

            migrationBuilder.DeleteData(
                table: "Accom_Facilities",
                keyColumn: "Id",
                keyValue: new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e1e1e1e1-e1e1-e1e1-e1e1-e1e1e1e1e1e1"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e2e2e2e2-e2e2-e2e2-e2e2-e2e2e2e2e2e2"));

            migrationBuilder.DeleteData(
                table: "Accom_Images",
                keyColumn: "Id",
                keyValue: new Guid("e3e3e3e3-e3e3-e3e3-e3e3-e3e3e3e3e3e3"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("12121212-3434-5656-7878-909090909090"));

            migrationBuilder.DeleteData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("23232323-4545-6767-8989-010101010101"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-2222-3333-4444-555566667777"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));
        }
    }
}
