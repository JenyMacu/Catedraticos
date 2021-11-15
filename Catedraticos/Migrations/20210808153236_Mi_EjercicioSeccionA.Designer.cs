﻿// <auto-generated />
using Catedraticos.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Catedraticos.Migrations
{
    [DbContext(typeof(Conn))]
    [Migration("20210808153236_Mi_EjercicioSeccionA")]
    partial class Mi_EjercicioSeccionA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EjercicioSeccionA.Models.PersonaModel", b =>
                {
                    b.Property<int>("CodigoPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoPersona")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<int>("EdadPersona")
                        .HasColumnType("int");

                    b.Property<string>("EstadoPersona")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("NombrePersona")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.HasKey("CodigoPersona");

                    b.ToTable("tbl_personas");
                });
#pragma warning restore 612, 618
        }
    }
}
