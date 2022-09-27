using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartamentoForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentoId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartamentoId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartamentId",
                table: "Seller",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartamentId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Seller",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartamentoId",
                table: "Seller",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentoId",
                table: "Seller",
                column: "DepartamentoId",
                principalTable: "Departament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
