using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralInfos_Accommodations_AccomId",
                table: "GeneralInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Accommodations_AccomId",
                table: "Policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralInfos",
                table: "GeneralInfos");

            migrationBuilder.DropIndex(
                name: "IX_GeneralInfos_AccommodationId",
                table: "GeneralInfos");

            migrationBuilder.DropColumn(
                name: "AccomId",
                table: "GeneralInfos");

            migrationBuilder.RenameColumn(
                name: "AccomId",
                table: "Policies",
                newName: "AccommodationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralInfos",
                table: "GeneralInfos",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Accommodations_AccommodationId",
                table: "Policies",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policies_Accommodations_AccommodationId",
                table: "Policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralInfos",
                table: "GeneralInfos");

            migrationBuilder.RenameColumn(
                name: "AccommodationId",
                table: "Policies",
                newName: "AccomId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccomId",
                table: "GeneralInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralInfos",
                table: "GeneralInfos",
                column: "AccomId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInfos_AccommodationId",
                table: "GeneralInfos",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralInfos_Accommodations_AccomId",
                table: "GeneralInfos",
                column: "AccomId",
                principalTable: "Accommodations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Policies_Accommodations_AccomId",
                table: "Policies",
                column: "AccomId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }
    }
}
