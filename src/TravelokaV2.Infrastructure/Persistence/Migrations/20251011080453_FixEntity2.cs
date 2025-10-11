using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelokaV2.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccomTypeId",
                table: "PaymentRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccomTypeId",
                table: "PaymentRecords",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
