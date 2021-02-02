﻿// <auto-generated />
using System;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Loja.Infra.Migrations
{
    [DbContext(typeof(LojaContexto))]
    partial class LojaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Loja.Domain.Domain.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Loja.Domain.Domain.PedidoItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("PedidosID")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PedidosID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Pedidos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("Codigo")
                        .IsUnique()
                        .HasFilter("[Codigo] IS NOT NULL");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Cliente", b =>
                {
                    b.OwnsOne("Loja.Domain.ValueObjects.CPF", "Cpf", b1 =>
                        {
                            b1.Property<int>("ClienteID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Cpf")
                                .IsRequired()
                                .HasColumnType("varchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("ClienteID");

                            b1.HasIndex("Cpf")
                                .IsUnique()
                                .HasFilter("[CPF] IS NOT NULL");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteID");
                        });

                    b.Navigation("Cpf");
                });

            modelBuilder.Entity("Loja.Domain.Domain.PedidoItem", b =>
                {
                    b.HasOne("Loja.Domain.Domain.Pedidos", null)
                        .WithMany("PedidoItems")
                        .HasForeignKey("PedidosID");

                    b.HasOne("Loja.Domain.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");

                    b.OwnsOne("Loja.Domain.ValueObjects.Dinheiro", "ValorProdutoNessePedido", b1 =>
                        {
                            b1.Property<int>("PedidoItemID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("ValorProdutoNessePedido");

                            b1.HasKey("PedidoItemID");

                            b1.ToTable("PedidoItem");

                            b1.WithOwner()
                                .HasForeignKey("PedidoItemID");
                        });

                    b.Navigation("Produto");

                    b.Navigation("ValorProdutoNessePedido");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Pedidos", b =>
                {
                    b.HasOne("Loja.Domain.Domain.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Produto", b =>
                {
                    b.OwnsOne("Loja.Domain.ValueObjects.CodigoBarras", "CodigoBarras", b1 =>
                        {
                            b1.Property<int>("ProdutoID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Codigo")
                                .IsRequired()
                                .HasColumnType("varchar(49)")
                                .HasColumnName("CodigoBarras");

                            b1.HasKey("ProdutoID");

                            b1.HasIndex("Codigo")
                                .IsUnique()
                                .HasFilter("[CodigoBarras] IS NOT NULL");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoID");
                        });

                    b.OwnsOne("Loja.Domain.ValueObjects.Dinheiro", "ValorDeVenda", b1 =>
                        {
                            b1.Property<int>("ProdutoID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("ValorDeVenda");

                            b1.HasKey("ProdutoID");

                            b1.ToTable("Produtos");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoID");
                        });

                    b.Navigation("CodigoBarras");

                    b.Navigation("ValorDeVenda");
                });

            modelBuilder.Entity("Loja.Domain.Domain.Pedidos", b =>
                {
                    b.Navigation("PedidoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
