using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_care.Dal.Migrations
{
    public partial class ReservationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BusyFrom",
                table: "Specialists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BusyTo",
                table: "Specialists",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusyFrom",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "BusyTo",
                table: "Specialists");
        }
    }
}
