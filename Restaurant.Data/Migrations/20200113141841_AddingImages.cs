using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_FoodItems_FoodItemId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FoodItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "FoodItemId",
                table: "Categories");

            migrationBuilder.AddColumn<byte[]>(
                name: "FoodItemImage",
                table: "FoodItems",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "CategoryImage",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodItemImage",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "FoodItemId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FoodItemId",
                table: "Categories",
                column: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_FoodItems_FoodItemId",
                table: "Categories",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
