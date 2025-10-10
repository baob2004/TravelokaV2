using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "GeneralInfos");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GeneralInfos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneralInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Policies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Policies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "GeneralInfos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "GeneralInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneralInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
