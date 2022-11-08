using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeSettings2.Migrations
{
    public partial class AddBikeToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontTyrePSI = table.Column<int>(type: "int", nullable: false),
                    RearTyrePSI = table.Column<int>(type: "int", nullable: false),
                    ForkPSI = table.Column<int>(type: "int", nullable: false),
                    ForkRebound = table.Column<int>(type: "int", nullable: false),
                    ShockPSI = table.Column<int>(type: "int", nullable: false),
                    ShockRebound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
