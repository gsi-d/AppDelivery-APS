using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPS.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoCampoObservacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "Pedido",
                newName: "Complemento");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "PedidoItem",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "PedidoItem");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Pedido",
                newName: "Observacoes");
        }
    }
}
