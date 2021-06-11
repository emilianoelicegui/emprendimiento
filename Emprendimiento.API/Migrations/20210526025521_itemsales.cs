using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Migrations
{
    public partial class itemsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_IdProduct",
                table: "ItemSales",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSales_Products_IdProduct",
                table: "ItemSales",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSales_Products_IdProduct",
                table: "ItemSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemSales_IdProduct",
                table: "ItemSales");
        }
    }
}
