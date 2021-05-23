using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Migrations
{
    public partial class spendingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Spendings");

            migrationBuilder.AddColumn<short>(
                name: "IdSpendingType",
                table: "Spendings",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "SpendingTypes",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_IdSpendingType",
                table: "Spendings",
                column: "IdSpendingType");

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_SpendingTypes_IdSpendingType",
                table: "Spendings",
                column: "IdSpendingType",
                principalTable: "SpendingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_SpendingTypes_IdSpendingType",
                table: "Spendings");

            migrationBuilder.DropTable(
                name: "SpendingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_IdSpendingType",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "IdSpendingType",
                table: "Spendings");

            migrationBuilder.AddColumn<short>(
                name: "Type",
                table: "Spendings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
