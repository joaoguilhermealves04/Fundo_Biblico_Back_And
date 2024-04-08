﻿// <auto-generated />
using System;
using FundoBiblico.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FundoBiblico.Repository.Migrations
{
    [DbContext(typeof(FundoBiblicoContext))]
    [Migration("20240328144415_Alteração no id ")]
    partial class Alteraçãonoid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FundoBiblico.Dominio.Entity.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IgrejaPertencenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroFilaEspera")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IgrejaPertencenteId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("FundoBiblico.Dominio.Entity.Igreja", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Igrejas", (string)null);
                });

            modelBuilder.Entity("FundoBiblico.Dominio.Entity.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IgrejaPertencenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IgrejaPertencenteId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("FundoBiblico.Dominio.Entity.Cliente", b =>
                {
                    b.HasOne("FundoBiblico.Dominio.Entity.Igreja", "IgrejaPertencente")
                        .WithMany()
                        .HasForeignKey("IgrejaPertencenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IgrejaPertencente");
                });

            modelBuilder.Entity("FundoBiblico.Dominio.Entity.Produto", b =>
                {
                    b.HasOne("FundoBiblico.Dominio.Entity.Igreja", "IgrejaPertencente")
                        .WithMany()
                        .HasForeignKey("IgrejaPertencenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IgrejaPertencente");
                });
#pragma warning restore 612, 618
        }
    }
}
