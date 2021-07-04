using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class UsuarioConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioConfirmacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(6)", nullable: true),
                    DateInicial = table.Column<DateTime>(nullable: false),
                    DateExpiracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioConfirmacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioConfirmacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioConfirmacao_UsuarioId",
                table: "UsuarioConfirmacao",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioConfirmacao");
        }
    }
}
