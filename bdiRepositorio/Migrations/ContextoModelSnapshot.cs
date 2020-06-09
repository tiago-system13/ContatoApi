﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using bdiRepositorio.Contextos;

namespace bdiRepositorio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bdiEntidades.Entidades.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("contato_dt_nascimento");

                    b.Property<int>("Idade")
                        .HasColumnName("contato_idade");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("contato_nome")
                        .HasMaxLength(60);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnName("contato_sexo")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("Contato","ContatoApi");
                });
#pragma warning restore 612, 618
        }
    }
}