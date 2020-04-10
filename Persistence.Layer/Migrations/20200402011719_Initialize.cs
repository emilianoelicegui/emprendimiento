using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Layer.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuRoles",
                columns: table => new
                {
                    MenuRolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRoles", x => x.MenuRolId);
                });

            migrationBuilder.CreateTable(
                name: "Menues",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    Url = table.Column<string>(nullable: true),
                    MenuRolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menues", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menues_MenuRoles_MenuRolId",
                        column: x => x.MenuRolId,
                        principalTable: "MenuRoles",
                        principalColumn: "MenuRolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    MenuRolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                    table.ForeignKey(
                        name: "FK_Roles_MenuRoles_MenuRolId",
                        column: x => x.MenuRolId,
                        principalTable: "MenuRoles",
                        principalColumn: "MenuRolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menues_MenuRolId",
                table: "Menues",
                column: "MenuRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MenuRolId",
                table: "Roles",
                column: "MenuRolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menues");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MenuRoles");
        }
    }
}
