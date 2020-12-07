using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BanhoTosa_Responsaveis_ResponsavelId",
                table: "BanhoTosa");

            migrationBuilder.DropIndex(
                name: "IX_BanhoTosa_ResponsavelId",
                table: "BanhoTosa");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "BanhoTosa");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "BanhoTosa");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Responsaveis",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Bichinhos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "BanhoTosa",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Atendimentos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Responsaveis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Bichinhos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "BanhoTosa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "BanhoTosa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "BanhoTosa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Atendimentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Hora",
                table: "Atendimentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BanhoTosa_ResponsavelId",
                table: "BanhoTosa",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BanhoTosa_Responsaveis_ResponsavelId",
                table: "BanhoTosa",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
