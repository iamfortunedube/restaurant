using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class UpdateShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_FoodItems_FoodItemId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ShoppingCartItems",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_FoodItems_FoodItemId",
                table: "ShoppingCartItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_FoodItems_FoodItemId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCartItems",
                newName: "ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "ShoppingCartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ShoppingCartItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ShoppingCartItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_FoodItems_FoodItemId",
                table: "ShoppingCartItems",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
