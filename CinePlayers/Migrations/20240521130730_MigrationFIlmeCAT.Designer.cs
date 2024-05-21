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
    [Migration("20240521130730_MigrationFIlmeCAT")]
    partial class MigrationFIlmeCAT
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinePlayers.Models.AvaliacoesFilme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Avaliacao")
                        .HasColumnType("float");

                    b.Property<Guid>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("FilmesAvaliacoes", (string)null);
                });

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

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elenco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
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

            modelBuilder.Entity("CinePlayers.Models.ReacoesFilme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reacoes")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("FilmesReacoes", (string)null);
                });

            modelBuilder.Entity("CinePlayers.Models.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumeroAssento")
                        .HasColumnType("int");

                    b.Property<Guid>("SessaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("CinePlayers.Models.SalaCinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalaCinema", (string)null);
                });

            modelBuilder.Entity("CinePlayers.Models.Sessao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraExibicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("SalaId");

                    b.ToTable("Sessao", (string)null);
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

            modelBuilder.Entity("CinePlayers.Models.AvaliacoesFilme", b =>
                {
                    b.HasOne("CinePlayers.Models.Filme", "Filme")
                        .WithMany("UsuariosQueAvaliaram")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.Usuario", "Usuario")
                        .WithMany("FilmesAvaliados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CinePlayers.Models.ReacoesFilme", b =>
                {
                    b.HasOne("CinePlayers.Models.Filme", "Filme")
                        .WithMany("UsuariosQueReagiram")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.Usuario", "Usuario")
                        .WithMany("FilmesReagidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CinePlayers.Models.Reserva", b =>
                {
                    b.HasOne("CinePlayers.Models.Sessao", "Sessao")
                        .WithMany("Reservas")
                        .HasForeignKey("SessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sessao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CinePlayers.Models.Sessao", b =>
                {
                    b.HasOne("CinePlayers.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinePlayers.Models.SalaCinema", "Sala")
                        .WithMany("Sessoes")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Sala");
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

            modelBuilder.Entity("CinePlayers.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");

                    b.Navigation("UsuariosQueAvaliaram");

                    b.Navigation("UsuariosQueReagiram");
                });

            modelBuilder.Entity("CinePlayers.Models.SalaCinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("CinePlayers.Models.Sessao", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CinePlayers.Models.Usuario", b =>
                {
                    b.Navigation("FilmesAvaliados");

                    b.Navigation("FilmesReagidos");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}