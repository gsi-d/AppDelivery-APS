using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppAPS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichaTecnica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaTecnica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ingrediente = table.Column<bool>(type: "bit", nullable: false),
                    NomeArquivoUpload = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FichaTecnicaId = table.Column<int>(type: "int", nullable: false),
                    FichaTecnicaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_FichaTecnica_FichaTecnicaId",
                        column: x => x.FichaTecnicaId,
                        principalTable: "FichaTecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_FichaTecnica_FichaTecnicaId1",
                        column: x => x.FichaTecnicaId1,
                        principalTable: "FichaTecnica",
                        principalColumn: "Id");
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
                        name: "FK_PedidoItem_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FichaTecnica",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao", "FichaTecnicaId", "FichaTecnicaId1", "Ingrediente", "Nome", "NomeArquivoUpload", "Preco" },
                values: new object[,]
                {
                    { 1, "Dois suculentos hambúrgueres de carne bovina grelhados, com queijo cheddar derretido, alface fresca, tomate maduro e molho especial. Tudo isso dentro de um pão macio com gergelim.", 1, null, false, "Cheeseburger Duplo", "/uploads/cheeseburger_duplo.jpg", 17.50m },
                    { 2, "Batatas fritas crocantes e douradas por fora, macias por dentro, temperadas na medida certa. Acompanhamento perfeito para qualquer refeição.", 1, null, false, "Batata Frita Grande", "/uploads/batata_frita_grande.jpeg", 8.99m },
                    { 3, "Peitos de frango suculentos e temperados, empanados em uma crosta crocante de ervas e especiarias. Perfeito para os amantes de frango frito.", 1, null, false, "Frango Empanado Crocante", "/uploads/frango_empanado.jpg", 15.00m },
                    { 4, "Milkshake cremoso de chocolate, feito com sorvete artesanal de alta qualidade, servido com chantilly e cobertura de chocolate.", 1, null, false, "Milkshake de Chocolate", "/uploads/milkshake_chocolate.jpg", 12.50m },
                    { 5, "Tortilla macia recheada com pedaços de frango grelhado, alface, tomate, queijo cheddar e molho ranch. Uma opção leve e deliciosa.", 1, null, false, "Wrap de Frango Grelhado", "/uploads/wrap_frango_grelhado.jpg", 14.75m },
                    { 6, "Hambúrguer com dois suculentos hambúrgueres de carne bovina, bacon crocante, queijo cheddar derretido, cebolas caramelizadas e molho especial. Acompanha batata frita e refrigerante.", 1, null, false, "Combo Bacon Duplo", "/uploads/combo_bacon_duplo.jpg", 25.99m },
                    { 7, "Pequenos pedaços de frango empanado, crocantes e suculentos, servidos com seu molho preferido. Ideal como lanche rápido ou acompanhamento.", 1, null, false, "Nuggets de Frango", "/uploads/nuggets_frango.jpg", 10.99m },
                    { 8, "Salada fresca de alface romana com frango grelhado, croutons crocantes e queijo parmesão ralado, tudo regado com molho Caesar cremoso.", 1, null, false, "Salada Caesar com Frango", "/uploads/salada_caesar_frango.jpg", 18.00m },
                    { 9, "Pizza individual com molho de tomate artesanal, fatias generosas de pepperoni, queijo mussarela derretido e massa fina e crocante.", 1, null, false, "Pizza Pepperoni Individual", "/uploads/pizza_pepperoni.jpg", 22.99m },
                    { 10, "Clássicas coxinhas recheadas com frango desfiado temperado e cremoso catupiry, envolvidas por uma massa dourada e crocante.", 1, null, false, "Coxinhas de Frango com Catupiry", "/uploads/coxinhas_frango_catupiry.jpg", 9.50m },
                    { 11, "Bebida refrescante feita com chá preto gelado, adoçado na medida certa e com um toque de limão fresco. Ideal para acompanhar seu lanche.", 1, null, false, "Chá Gelado de Limão", "/uploads/cha_gelado_limao.jpg", 6.50m },
                    { 12, "Sorvete cremoso de baunilha servido com uma deliciosa calda de caramelo, perfeito para os amantes de sobremesas doces e suaves.", 1, null, false, "Sorvete de Baunilha com Calda de Caramelo", "/uploads/sorvete_baunilha_caramelo.jpg", 8.75m },
                    { 13, "Hambúrguer 100% vegano, feito com proteína vegetal, alface, tomate, cebola roxa e maionese vegana, servido em pão integral.", 1, null, false, "Hambúrguer Vegano", "/uploads/hamburguer_vegano.jpg", 19.99m },
                    { 14, "Pastel frito recheado com carne moída temperada e azeitonas, envolto em uma massa crocante e dourada. Um lanche clássico e saboroso.", 1, null, false, "Pastel de Carne", "/uploads/pastel_carne.jpg", 7.50m },
                    { 15, "Pão de hot-dog macio com salsicha grelhada, coberta com molho de tomate caseiro, queijo cheddar derretido, batata palha e milho verde.", 1, null, false, "Cachorro-Quente Especial", "/uploads/cachorro_quente_especial.jpg", 13.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FichaTecnicaId",
                table: "Produto",
                column: "FichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FichaTecnicaId1",
                table: "Produto",
                column: "FichaTecnicaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "FichaTecnica");
        }
    }
}
