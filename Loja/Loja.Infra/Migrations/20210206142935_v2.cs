using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loja.Infra.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidosID",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoID",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos");

            migrationBuilder.AddColumn<byte[]>(
                name: "VersaoLinha",
                table: "Produtos",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidosID",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidosID",
                table: "PedidoItem",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoID",
                table: "PedidoItem",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidosID",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoID",
                table: "PedidoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "VersaoLinha",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "PedidoItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PedidosID",
                table: "PedidoItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Pedidos_PedidosID",
                table: "PedidoItem",
                column: "PedidosID",
                principalTable: "Pedidos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produtos_ProdutoID",
                table: "PedidoItem",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
