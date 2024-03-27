﻿// <auto-generated />
using System;
using CinePlayers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinePlayers.Migrations
{
    [DbContext(typeof(CinePlayersDataContext))]
    [Migration("20240326234235_Reacoes")]
    partial class Reacoes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinePlayers.Models.Filme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AnoDeLancamento")
                        .HasColumnType("datetime2");

                    b.Property<double>("AvaliacaoDosCriticos")
                        .HasColumnType("float");

                    b.Property<double>("AvaliacaoDosUsuarios")
                        .HasColumnType("float");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elenco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tag")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Filme", (string)null);
                });

            modelBuilder.Entity("CinePlayers.Models.ReacoesFilmes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reacoes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reacoes", (string)null);
                });

            modelBuilder.Entity("CinePlayers.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mtb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("FilmeReacoesFilmes", b =>
                {
                    b.Property<Guid>("FilmesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuariosQueReagiramId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmesId", "UsuariosQueReagiramId");

                    b.HasIndex("UsuariosQueReagiramId");

                    b.ToTable("FilmeReacoesFilmes");
                });

            modelBuilder.Entity("FilmesFavoritos", b =>
                {
                    b.Property<Guid>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmeId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("FilmesFavoritos");
                });

            modelBuilder.Entity("ReacoesFilmesUsuario", b =>
                {
                    b.Property<Guid>("FilmesReagidosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuariosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmesReagidosId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("ReacoesFilmesUsuario");
                });

            modelBuilder.Entity("FilmeReacoesFilmes", b =>
                {
                    b.HasOne("CinePlayers.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.ReacoesFilmes", null)
                        .WithMany()
                        .HasForeignKey("UsuariosQueReagiramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmesFavoritos", b =>
                {
                    b.HasOne("CinePlayers.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FilmesFavoritos_FilmeId");

                    b.HasOne("CinePlayers.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FilmesFavoritos_UsuarioId");
                });

            modelBuilder.Entity("ReacoesFilmesUsuario", b =>
                {
                    b.HasOne("CinePlayers.Models.ReacoesFilmes", null)
                        .WithMany()
                        .HasForeignKey("FilmesReagidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
