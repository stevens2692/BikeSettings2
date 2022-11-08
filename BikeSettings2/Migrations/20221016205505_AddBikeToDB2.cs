using Microsoft.EntityFrameworkCore.Migrations;
using BikeSettings2.Models;
#nullable disable

namespace BikeSettings2.Migrations
{
    public partial class AddBikeToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Brand", table: "Bikes", newName: "Manufacturer");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Manufacturer", table: "Bikes", newName: "Brand");
        }
    }
}
