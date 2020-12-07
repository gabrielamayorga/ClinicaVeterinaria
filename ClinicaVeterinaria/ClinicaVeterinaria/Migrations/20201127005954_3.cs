using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Veterinario_VeterinarioId",
                table: "Atendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinario",
                table: "Veterinario");

            migrationBuilder.RenameTable(
                name: "Veterinario",
                newName: "Veterinarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarios",
                table: "Veterinarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Veterinarios_VeterinarioId",
                table: "Atendimentos",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Veterinarios_VeterinarioId",
                table: "Atendimentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarios",
                table: "Veterinarios");

            migrationBuilder.RenameTable(
                name: "Veterinarios",
                newName: "Veterinario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinario",
                table: "Veterinario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Veterinario_VeterinarioId",
                table: "Atendimentos",
                column: "VeterinarioId",
                principalTable: "Veterinario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
