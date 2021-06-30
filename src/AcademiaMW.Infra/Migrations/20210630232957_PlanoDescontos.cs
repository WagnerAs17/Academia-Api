using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class PlanoDescontos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Planos_PlanoId",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PlanoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "TempoContrato",
                table: "Contratos");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoDescontoId",
                table: "Contratos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PlanoDescontos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    PlanoId = table.Column<Guid>(nullable: false),
                    QuantidadeMeses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDescontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoDescontos_Planos_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PlanoDescontoId",
                table: "Contratos",
                column: "PlanoDescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDescontos_PlanoId",
                table: "PlanoDescontos",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_PlanoDescontos_PlanoDescontoId",
                table: "Contratos",
                column: "PlanoDescontoId",
                principalTable: "PlanoDescontos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_PlanoDescontos_PlanoDescontoId",
                table: "Contratos");

            migrationBuilder.DropTable(
                name: "PlanoDescontos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_PlanoDescontoId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "PlanoDescontoId",
                table: "Contratos");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoId",
                table: "Contratos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TempoContrato",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PlanoId",
                table: "Contratos",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Planos_PlanoId",
                table: "Contratos",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
