using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Repositories.Migrations
{
    public partial class updateMenuRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "MenuRol",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuRol",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdMenu",
                table: "MenuRol",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "MenuRol",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Menus_MenuId",
                table: "MenuRol");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRol_Roles_RolId",
                table: "MenuRol");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_MenuId",
                table: "MenuRol");

            migrationBuilder.DropIndex(
                name: "IX_MenuRol_RolId",
                table: "MenuRol");

            migrationBuilder.DropColumn(
                name: "IdMenu",
                table: "MenuRol");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "MenuRol");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "MenuRol",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuRol",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
