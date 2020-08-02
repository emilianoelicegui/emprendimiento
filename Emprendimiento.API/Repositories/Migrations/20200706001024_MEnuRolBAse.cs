using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Repositories.Migrations
{
    public partial class MEnuRolBAse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MenuRol",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MenuRol");
        }
    }
}
