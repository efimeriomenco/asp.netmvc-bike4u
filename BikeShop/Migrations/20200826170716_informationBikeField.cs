using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeShop.Migrations
{
    public partial class informationBikeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "informationBike",
                table: "Bike",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "informationBike",
                table: "Bike");
        }
    }
}
