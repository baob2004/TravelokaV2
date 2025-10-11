using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_BedTypes_BedTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CategoryId",
                table: "Rooms",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_BedTypes_BedTypeId",
                table: "Rooms",
                column: "BedTypeId",
                principalTable: "BedTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                table: "Rooms",
                column: "CancelPolicyId",
                principalTable: "CancelPolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_CategoryId",
                table: "Rooms",
                column: "CategoryId",
                principalTable: "RoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_BedTypes_BedTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCategories_CategoryId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CategoryId",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomCategoryId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000001"),
                column: "RoomCategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("77777777-0000-0000-0000-000000000002"),
                column: "RoomCategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_BedTypes_BedTypeId",
                table: "Rooms",
                column: "BedTypeId",
                principalTable: "BedTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_CancelPolicies_CancelPolicyId",
                table: "Rooms",
                column: "CancelPolicyId",
                principalTable: "CancelPolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCategories_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId",
                principalTable: "RoomCategories",
                principalColumn: "Id");
        }
    }
}
