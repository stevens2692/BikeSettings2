using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSettings2.Migrations
{
    public partial class NonnullableFrontTyrePSI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FrontTyrePSI",
                table: "Bikes",
                nullable: false
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FrontTyrePSI",
                table: "Bikes",
                nullable: true
                );
        }
    }
}
