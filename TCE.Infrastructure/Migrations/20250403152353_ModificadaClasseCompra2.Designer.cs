﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCE.Infrastructure.Data;

#nullable disable

namespace TCE.Infrastructure.Migrations
{
    [DbContext(typeof(TCEDbContext))]
    [Migration("20250403152353_ModificadaClasseCompra2")]
    partial class ModificadaClasseCompra2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.14");

            modelBuilder.Entity("TCE.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TCE.Domain.Entities.Compra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdempotencyKey")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("IdempotencyKey")
                        .IsUnique();

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("TCE.Domain.Entities.Compra", b =>
                {
                    b.HasOne("TCE.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Compras")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TCE.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Compras");
                });
#pragma warning restore 612, 618
        }
    }
}
