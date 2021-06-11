using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Migrations
{
    public partial class updateSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ClientId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "SaleState",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Payments",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdClient",
                table: "Payments",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_IdClient",
                table: "Payments",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Clients_IdClient",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_IdClient",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SaleState",
                table: "Sales");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClientId",
                table: "Payments",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Clients_ClientId",
                table: "Payments",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
