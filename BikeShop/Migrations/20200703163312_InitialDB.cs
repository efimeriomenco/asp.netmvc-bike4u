using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeShop.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    descriptionBike = table.Column<string>(nullable: true),
                    available = table.Column<bool>(nullable: false),
                    favorite = table.Column<bool>(nullable: false),
                    priceBike = table.Column<int>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bike_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_categoryID",
                table: "Bike",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
