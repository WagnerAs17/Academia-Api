using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademiaMW.Infra.Migrations
{
    public partial class CampoPercentualModelContratoRemovido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "Contratos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Percentual",
                table: "Contratos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
