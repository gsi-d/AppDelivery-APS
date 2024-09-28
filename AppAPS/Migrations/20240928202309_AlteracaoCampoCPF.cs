using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPS.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoCampoCPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CPF",
                table: "Pedido",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedido_CPF",
                table: "Pedido");
        }
    }
}
