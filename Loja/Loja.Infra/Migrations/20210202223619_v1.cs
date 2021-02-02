using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    CodigoBarras = table.Column<string>(type: "varchar(49)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorDeVenda = table.Column<string>(type: "varchar(50)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: true),
                    ValorProdutoNessePedido = table.Column<string>(type: "varchar(50)", nullable: true),
                    PedidosID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedidos_PedidosID",
                        column: x => x.PedidosID,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Codigo",
                table: "Clientes",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidosID",
                table: "PedidoItem",
                column: "PedidosID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoID",
                table: "PedidoItem",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Codigo",
                table: "Pedidos",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Codigo",
                table: "Produtos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarras",
                table: "Produtos",
                column: "CodigoBarras",
                unique: true,
                filter: "[CodigoBarras] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
