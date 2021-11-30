using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class treino_treinoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true),
                    ClienteId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treinos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreinoItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TreinoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Repeticao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreinoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreinoItens_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreinoItens_TreinoId",
                table: "TreinoItens",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Treinos_ClienteId",
                table: "Treinos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreinoItens");

            migrationBuilder.DropTable(
                name: "Treinos");
        }
    }
}
