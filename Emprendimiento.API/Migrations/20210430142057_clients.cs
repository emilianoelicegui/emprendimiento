using Microsoft.EntityFrameworkCore.Migrations;

namespace Emprendimiento.API.Migrations
{
    public partial class clients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_Companies_CompanyId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_CompanyId",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Spendings");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Dni = table.Column<long>(nullable: false),
                    Cuit = table.Column<long>(nullable: false),
                    CodArea = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IdCompany = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_IdCompany",
                table: "Spendings",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdCompany",
                table: "Clients",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_Companies_IdCompany",
                table: "Spendings",
                column: "IdCompany",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_Companies_IdCompany",
                table: "Spendings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_IdCompany",
                table: "Spendings");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Spendings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_CompanyId",
                table: "Spendings",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_Companies_CompanyId",
                table: "Spendings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
