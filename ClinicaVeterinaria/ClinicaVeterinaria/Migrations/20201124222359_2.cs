using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Bichinhos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adocao",
                table: "Bichinhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "Bichinhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especie",
                table: "Bichinhos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Bichinhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Bichinhos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    CRMV = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BanhoTosa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BichinhoId = table.Column<int>(nullable: false),
                    ResponsavelId = table.Column<int>(nullable: false),
                    Horario = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanhoTosa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanhoTosa_Bichinhos_BichinhoId",
                        column: x => x.BichinhoId,
                        principalTable: "Bichinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BanhoTosa_Responsaveis_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsaveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BichinhoId = table.Column<int>(nullable: false),
                    ResponsavelId = table.Column<int>(nullable: false),
                    VeterinarioId = table.Column<int>(nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Hora = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Bichinhos_BichinhoId",
                        column: x => x.BichinhoId,
                        principalTable: "Bichinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Responsaveis_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsaveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Veterinario_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bichinhos_ResponsavelId",
                table: "Bichinhos",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_BichinhoId",
                table: "Atendimentos",
                column: "BichinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ResponsavelId",
                table: "Atendimentos",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_VeterinarioId",
                table: "Atendimentos",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_BanhoTosa_BichinhoId",
                table: "BanhoTosa",
                column: "BichinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_BanhoTosa_ResponsavelId",
                table: "BanhoTosa",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bichinhos_Responsaveis_ResponsavelId",
                table: "Bichinhos",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bichinhos_Responsaveis_ResponsavelId",
                table: "Bichinhos");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "BanhoTosa");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropIndex(
                name: "IX_Bichinhos_ResponsavelId",
                table: "Bichinhos");

            migrationBuilder.DropColumn(
                name: "Adocao",
                table: "Bichinhos");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Bichinhos");

            migrationBuilder.DropColumn(
                name: "Especie",
                table: "Bichinhos");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Bichinhos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Bichinhos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Bichinhos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
