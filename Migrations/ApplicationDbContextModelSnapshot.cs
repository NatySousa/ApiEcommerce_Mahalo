﻿// <auto-generated />
using System;
using API_Desafio_Angular.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Desafio_Angular.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("API_Desafio_Angular.Entities.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Senha");

                    b.HasKey("IdCliente");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Endereco", b =>
                {
                    b.Property<Guid>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("IdEndereco");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("Cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Complemento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("Estado");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("char(36)")
                        .HasColumnName("IdCliente");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Numero");

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdCliente");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("IdItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("IdItemPedido");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("char(36)")
                        .HasColumnName("IdPedido");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("char(36)")
                        .HasColumnName("IdProduto");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeProduto");

                    b.Property<float>("ValorTotalItem")
                        .HasColumnType("float")
                        .HasColumnName("ValorTotalItem");

                    b.Property<float>("ValorUnitarioProduto")
                        .HasColumnType("float")
                        .HasColumnName("ValorUnitarioProduto");

                    b.HasKey("IdItemPedido");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Pedido", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("IdPedido");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("date")
                        .HasColumnName("DataPedido");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("char(36)")
                        .HasColumnName("IdCliente");

                    b.Property<Guid?>("IdEndereco")
                        .HasColumnType("char(36)")
                        .HasColumnName("IdEndereco");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorTotal");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Produto", b =>
                {
                    b.Property<Guid>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("IdProduto");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UnidadeMedida");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Endereco", b =>
                {
                    b.HasOne("API_Desafio_Angular.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.ItemPedido", b =>
                {
                    b.HasOne("API_Desafio_Angular.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Desafio_Angular.Entities.Produto", "Produto")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Pedido", b =>
                {
                    b.HasOne("API_Desafio_Angular.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Desafio_Angular.Entities.Endereco", "EnderecoEntrega")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdEndereco");

                    b.Navigation("Cliente");

                    b.Navigation("EnderecoEntrega");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Cliente", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Endereco", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("API_Desafio_Angular.Entities.Produto", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}