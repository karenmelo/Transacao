using Microsoft.EntityFrameworkCore.Migrations;

namespace Pagamento.Data.Migrations
{
    public partial class InclusaoCvc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cvc",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cvc",
                table: "Transacoes");
        }
    }
}
