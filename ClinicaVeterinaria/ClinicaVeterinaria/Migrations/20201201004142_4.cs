using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Responsaveis_ResponsavelId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_ResponsavelId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Atendimentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ResponsavelId",
                table: "Atendimentos",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Responsaveis_ResponsavelId",
                table: "Atendimentos",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
