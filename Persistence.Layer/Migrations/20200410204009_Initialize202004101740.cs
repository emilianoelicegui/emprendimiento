using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Layer.Migrations
{
    public partial class Initialize202004101740 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Roles_RolId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Menus_RolId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRol",
                table: "Users",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IdRol",
                table: "Menus",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Roles_IdRol",
                table: "Menus",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRol",
                table: "Users",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Roles_IdRol",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRol",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdRol",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Menus_IdRol",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RolId",
                table: "Menus",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Roles_RolId",
                table: "Menus",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
