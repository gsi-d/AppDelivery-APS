using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAPS.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFichaTecnica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FichaTecnicaId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFichaTecnica",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FichaTecnica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaTecnica_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FichaTecnicaId",
                table: "Produto",
                column: "FichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdFichaTecnica",
                table: "Produto",
                column: "IdFichaTecnica");

            migrationBuilder.CreateIndex(
                name: "IX_FichaTecnica_IdProduto",
                table: "FichaTecnica",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_FichaTecnica_FichaTecnicaId",
                table: "Produto",
                column: "FichaTecnicaId",
                principalTable: "FichaTecnica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_FichaTecnica_IdFichaTecnica",
                table: "Produto",
                column: "IdFichaTecnica",
                principalTable: "FichaTecnica",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_FichaTecnica_FichaTecnicaId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_FichaTecnica_IdFichaTecnica",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "FichaTecnica");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Produto_FichaTecnicaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdFichaTecnica",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "FichaTecnicaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdFichaTecnica",
                table: "Produto");
        }
    }
}
