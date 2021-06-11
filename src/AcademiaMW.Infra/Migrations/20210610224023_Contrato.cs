using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class Contrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_PlanoValores_PlanoValorId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "PlanoValores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PlanoValorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PlanoValorId",
                table: "Clientes");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Planos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDesativacao",
                table: "Planos",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Planos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ContratoId",
                table: "Clientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAquisicao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    TempoContrato = table.Column<int>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    PlanoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContratoId",
                table: "Clientes",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PlanoId",
                table: "Contratos",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Contratos_ContratoId",
                table: "Clientes",
                column: "ContratoId",
                principalTable: "Contratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Contratos_ContratoId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ContratoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "DataDesativacao",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Planos");

            migrationBuilder.DropColumn(
                name: "ContratoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Clientes");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoValorId",
                table: "Clientes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlanoValores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PlanoId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoValores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoValores_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PlanoValorId",
                table: "Clientes",
                column: "PlanoValorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoValores_PlanoId",
                table: "PlanoValores",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_PlanoValores_PlanoValorId",
                table: "Clientes",
                column: "PlanoValorId",
                principalTable: "PlanoValores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
