using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Repositories.Migrations
{
    public partial class lastStartUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastStart",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastStart",
                table: "Users");
        }
    }
}
