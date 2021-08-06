using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Migrations
{
    public partial class chauCURDATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DolarBlueValues",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "DolarBlueValues",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
