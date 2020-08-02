using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Repositories.Migrations
{
    public partial class MenuRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuRol",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRol");
        }
    }
}
