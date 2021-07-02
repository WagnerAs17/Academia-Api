using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class ValorPlanoDesconto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoDescontos_Planos_PlanoId",
                table: "PlanoDescontos");

            migrationBuilder.DropIndex(
                name: "IX_PlanoDescontos_PlanoId",
                table: "PlanoDescontos");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "PlanoDescontos");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoValorId",
                table: "PlanoDescontos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDescontos_PlanoValorId",
                table: "PlanoDescontos",
                column: "PlanoValorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoDescontos_PlanoValor_PlanoValorId",
                table: "PlanoDescontos",
                column: "PlanoValorId",
                principalTable: "PlanoValor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoDescontos_PlanoValor_PlanoValorId",
                table: "PlanoDescontos");

            migrationBuilder.DropIndex(
                name: "IX_PlanoDescontos_PlanoValorId",
                table: "PlanoDescontos");

            migrationBuilder.DropColumn(
                name: "PlanoValorId",
                table: "PlanoDescontos");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanoId",
                table: "PlanoDescontos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PlanoDescontos_PlanoId",
                table: "PlanoDescontos",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoDescontos_Planos_PlanoId",
                table: "PlanoDescontos",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
