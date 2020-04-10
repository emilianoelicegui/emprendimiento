using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Layer.Migrations
{
    public partial class Initialize202004101703 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menues",
                table: "Menues");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rols");

            migrationBuilder.RenameTable(
                name: "Menues",
                newName: "Menus");

            migrationBuilder.RenameIndex(
                name: "IX_Menues_RolId",
                table: "Menus",
                newName: "IX_Menus_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols",
                table: "Rols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Rols_RolId",
                table: "Menus",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rols_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Rols_RolId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rols_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols",
                table: "Rols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Rols",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menues");

            migrationBuilder.RenameIndex(
                name: "IX_Menus_RolId",
                table: "Menues",
                newName: "IX_Menues_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menues",
                table: "Menues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues",
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
