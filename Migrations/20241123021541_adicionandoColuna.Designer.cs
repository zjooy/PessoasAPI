﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cadastroPessoas.DataContext;

#nullable disable

namespace cadastroPessoas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241123021541_adicionandoColuna")]
    partial class adicionandoColuna
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cadastroPessoas.Models.PessoaModel", b =>
                {
                    b.Property<int>("ID_Pessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pessoa"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DT_Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DT_Aniversario")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DT_Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Pessoa");

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
