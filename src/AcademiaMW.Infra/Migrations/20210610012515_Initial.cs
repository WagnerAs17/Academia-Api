using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailConfirmado = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoValores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true),
                    PlanoId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(100)", nullable: false),
                    ClaimValue = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", nullable: true),
                    CPF_Numero = table.Column<string>(type: "varchar(11)", nullable: true),
                    Email_Endereco = table.Column<string>(type: "varchar(1000)", nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "varchar(350)", nullable: true),
                    Endereco_Numero = table.Column<string>(type: "varchar(15)", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "varchar(250)", nullable: true),
                    Endereco_Complemento = table.Column<string>(type: "varchar(200)", nullable: true),
                    Endereco_Cep = table.Column<string>(type: "varchar(8)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "varchar(350)", nullable: true),
                    Endereco_Estado = table.Column<string>(type: "varchar(2)", nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    PlanoValorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_PlanoValores_PlanoValorId",
                        column: x => x.PlanoValorId,
                        principalTable: "PlanoValores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PlanoValorId",
                table: "Clientes",
                column: "PlanoValorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_UsuarioId",
                table: "Permissoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoValores_PlanoId",
                table: "PlanoValores",
                column: "PlanoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "PlanoValores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
