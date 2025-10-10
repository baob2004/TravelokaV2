using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUpdateByToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "RoomCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "CancelPolicies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "BedTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "AccomTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555566667777"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-2222-3333-4444-555566667777"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000001"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000002"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("12121212-3434-5656-7878-909090909090"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("23232323-4545-6767-8989-010101010101"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000001"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000002"),
                column: "UpdateBy",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "RoomCategories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "Facilities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "CancelPolicies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "BedTypes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "AccomTypes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdateBy",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccomTypes",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-2222-3333-4444-555566667777"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-2222-3333-4444-555566667777"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "BedTypes",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "CancelPolicies",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f1f1-f1f1-f1f1-f1f1-f1f1f1f1f1f1"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000001"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("99999999-0000-0000-0000-000000000002"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("12121212-3434-5656-7878-909090909090"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomCategories",
                keyColumn: "Id",
                keyValue: new Guid("23232323-4545-6767-8989-010101010101"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000001"),
                column: "UpdateBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000002"),
                column: "UpdateBy",
                value: null);
        }
    }
}
