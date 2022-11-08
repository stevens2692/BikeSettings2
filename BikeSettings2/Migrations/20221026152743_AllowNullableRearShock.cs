using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSettings2.Migrations
{
    public partial class AllowNullableRearShock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>
                (
                    name: "ShockPSI",
                    table: "Bikes",
                    nullable: true
                );
            migrationBuilder.AlterColumn<int>
                (
                    name: "ShockRebound",
                    table: "Bikes",
                    nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>
                (
                    name: "ShockPSI",
                    table: "Bikes",
                    nullable: false
                );
            migrationBuilder.AlterColumn<int>
                (
                    name: "ShockRebound",
                    table: "Bikes",
                    nullable: false
                );

        }
    }
}
