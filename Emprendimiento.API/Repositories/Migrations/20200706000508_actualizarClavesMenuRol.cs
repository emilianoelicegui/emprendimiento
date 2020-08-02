using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Repositories.Migrations
{
    public partial class actualizarClavesMenuRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Menus_MenuId",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Roles_RolId",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Roles_IdRol",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_IdRol",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_MenuId",
                table: "MenuRol");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_RolId",
                table: "MenuRol");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MenuRol");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "MenuRol");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MenuRol",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuRol",
                table: "MenuRol",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_IdMenu",
                table: "MenuRol",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_IdRol",
                table: "MenuRol",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Menus_IdMenu",
                table: "MenuRol",
                column: "IdMenu",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Roles_IdRol",
                table: "MenuRol",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Menus_IdMenu",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Roles_IdRol",
                table: "MenuRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuRol",
                table: "MenuRol");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_IdMenu",
                table: "MenuRol");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_IdRol",
                table: "MenuRol");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenuRol");

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MenuRol",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "MenuRol",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IdRol",
                table: "Menus",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_MenuId",
                table: "MenuRol",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol_RolId",
                table: "MenuRol",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Menus_MenuId",
                table: "MenuRol",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRol_Roles_RolId",
                table: "MenuRol",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Roles_IdRol",
                table: "Menus",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
