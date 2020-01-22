using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class ChangeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetCategory",
                table: "FoodItems");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FoodItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoodItems");

            migrationBuilder.AddColumn<string>(
                name: "GetCategory",
                table: "FoodItems",
                nullable: true);
        }
    }
}
