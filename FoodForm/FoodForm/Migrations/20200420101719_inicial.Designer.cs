﻿// <auto-generated />
using System;
using FoodForm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodForm.Migrations
{
    [DbContext(typeof(FoodFormDB))]
    [Migration("20200420101719_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodForm.Models.Comentarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceitaFK")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReceitaFK");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("FoodForm.Models.Denuncias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceitaFK")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReceitaFK");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("FoodForm.Models.Gostos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Gosto")
                        .HasColumnType("bit");

                    b.Property<int>("ReceitaFK")
                        .HasColumnType("int");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReceitaFK");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Gostos");
                });

            modelBuilder.Entity("FoodForm.Models.Moderadores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Moderadores");
                });

            modelBuilder.Entity("FoodForm.Models.Receitas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilizadorFK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UtilizadorFK");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("FoodForm.Models.Utilizadores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("FoodForm.Models.Comentarios", b =>
                {
                    b.HasOne("FoodForm.Models.Receitas", "Receita")
                        .WithMany("ListaDeComentarios")
                        .HasForeignKey("ReceitaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForm.Models.Utilizadores", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodForm.Models.Denuncias", b =>
                {
                    b.HasOne("FoodForm.Models.Receitas", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForm.Models.Utilizadores", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodForm.Models.Gostos", b =>
                {
                    b.HasOne("FoodForm.Models.Receitas", "Receita")
                        .WithMany()
                        .HasForeignKey("ReceitaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodForm.Models.Utilizadores", "Utilizador")
                        .WithMany()
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodForm.Models.Receitas", b =>
                {
                    b.HasOne("FoodForm.Models.Utilizadores", "Utilizador")
                        .WithMany("ListaDeReceitas")
                        .HasForeignKey("UtilizadorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
