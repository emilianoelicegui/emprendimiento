using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Layer.Migrations
{
    public partial class Initialize20200410165400 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menues",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Menues");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Roles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menues",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Menues",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Menues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Menues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menues",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menues",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Menues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menues");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Menues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Menues",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Menues",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menues",
                table: "Menues",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menues_Roles_RolId",
                table: "Menues",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "RolId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
