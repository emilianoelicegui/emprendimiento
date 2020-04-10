using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Layer.Migrations
{
    public partial class Initialize202004102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menues_MenuRoles_MenuRolId",
                table: "Menues");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_MenuRoles_MenuRolId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "MenuRoles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_MenuRolId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Menues_MenuRolId",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "MenuRolId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MenuRolId",
                table: "Menues");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Menues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menues_RolId",
                table: "Menues",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues");

            migrationBuilder.DropIndex(
                name: "IX_Menues_RolId",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Menues");

            migrationBuilder.AddColumn<int>(
                name: "MenuRolId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuRolId",
                table: "Menues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuRoles",
                columns: table => new
                {
                    MenuRolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRoles", x => x.MenuRolId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MenuRolId",
                table: "Roles",
                column: "MenuRolId");

            migrationBuilder.CreateIndex(
                name: "IX_Menues_MenuRolId",
                table: "Menues",
                column: "MenuRolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menues_MenuRoles_MenuRolId",
                table: "Menues",
                column: "MenuRolId",
                principalTable: "MenuRoles",
                principalColumn: "MenuRolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_MenuRoles_MenuRolId",
                table: "Roles",
                column: "MenuRolId",
                principalTable: "MenuRoles",
                principalColumn: "MenuRolId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
