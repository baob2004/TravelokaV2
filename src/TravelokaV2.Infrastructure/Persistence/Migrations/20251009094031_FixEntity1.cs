using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_Room_RoomId",
                table: "PaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_BedTypes_BedTypeId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_CancelPolicies_CancelPolicyId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomCategories_RoomCategoryId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_RoomCategoryId",
                table: "Rooms",
                newName: "IX_Rooms_RoomCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_CancelPolicyId",
                table: "Rooms",
                newName: "IX_Rooms_CancelPolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_BedTypeId",
                table: "Rooms",
                newName: "IX_Rooms_BedTypeId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccomId",
                table: "RoomCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccommodationId",
                table: "RoomCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_AccomId",
                table: "RoomCategories",
                column: "AccomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCategories_AccommodationId",
                table: "RoomCategories",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_Rooms_RoomId",
                table: "PaymentRecords",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCategories_Accommodations_AccomId",
                table: "RoomCategories",
                column: "AccomId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCategories_Accommodations_AccommodationId",
                table: "RoomCategories",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRecords_Rooms_RoomId",
                table: "PaymentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCategories_Accommodations_AccomId",
                table: "RoomCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCategories_Accommodations_AccommodationId",
                table: "RoomCategories");

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
                name: "IX_RoomCategories_AccomId",
                table: "RoomCategories");

            migrationBuilder.DropIndex(
                name: "IX_RoomCategories_AccommodationId",
                table: "RoomCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AccomId",
                table: "RoomCategories");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "RoomCategories");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Room",
                newName: "IX_Room_RoomCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_CancelPolicyId",
                table: "Room",
                newName: "IX_Room_CancelPolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BedTypeId",
                table: "Room",
                newName: "IX_Room_BedTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRecords_Room_RoomId",
                table: "PaymentRecords",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_BedTypes_BedTypeId",
                table: "Room",
                column: "BedTypeId",
                principalTable: "BedTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_CancelPolicies_CancelPolicyId",
                table: "Room",
                column: "CancelPolicyId",
                principalTable: "CancelPolicies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomCategories_RoomCategoryId",
                table: "Room",
                column: "RoomCategoryId",
                principalTable: "RoomCategories",
                principalColumn: "Id");
        }
    }
}
