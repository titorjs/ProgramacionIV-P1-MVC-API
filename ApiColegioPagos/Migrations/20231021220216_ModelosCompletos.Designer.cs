﻿// <auto-generated />
using ApiColegioPagos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiColegioPagos.Migrations
{
    [DbContext(typeof(ApiColegioPagosDbContext))]
    [Migration("20231021220216_ModelosCompletos")]
    partial class ModelosCompletos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiColegioPagos.Models.Estudiante", b =>
                {
                    b.Property<int>("Est_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Est_id"));

                    b.Property<bool>("Est_activo")
                        .HasColumnType("bit");

                    b.Property<int>("Est_cedula")
                        .HasColumnType("int");

                    b.Property<string>("Est_direccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Est_nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Pen_id")
                        .HasColumnType("int");

                    b.HasKey("Est_id");

                    b.HasIndex("Pen_id");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Global", b =>
                {
                    b.Property<int>("Glo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Glo_id"));

                    b.Property<string>("Glo_nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Glo_valor")
                        .HasColumnType("int");

                    b.HasKey("Glo_id");

                    b.ToTable("Globals");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Pago", b =>
                {
                    b.Property<int>("Pag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pag_id"));

                    b.Property<int>("Est_id")
                        .HasColumnType("int");

                    b.Property<int>("Pag_cuota")
                        .HasColumnType("int");

                    b.Property<int>("Pen_id")
                        .HasColumnType("int");

                    b.HasKey("Pag_id");

                    b.HasIndex("Est_id");

                    b.HasIndex("Pen_id");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Pension", b =>
                {
                    b.Property<int>("Pen_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pen_id"));

                    b.Property<string>("Pen_nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Pen_valor")
                        .HasColumnType("real");

                    b.HasKey("Pen_id");

                    b.ToTable("Pensiones");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Estudiante", b =>
                {
                    b.HasOne("ApiColegioPagos.Models.Pension", "Pension")
                        .WithMany("Estudites")
                        .HasForeignKey("Pen_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pension");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Pago", b =>
                {
                    b.HasOne("ApiColegioPagos.Models.Estudiante", "Estudiante")
                        .WithMany("Pagos")
                        .HasForeignKey("Est_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiColegioPagos.Models.Pension", "Pension")
                        .WithMany("Pagos")
                        .HasForeignKey("Pen_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Pension");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Estudiante", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("ApiColegioPagos.Models.Pension", b =>
                {
                    b.Navigation("Estudites");

                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
