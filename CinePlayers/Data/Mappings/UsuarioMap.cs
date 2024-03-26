using CinePlayers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlayers.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Senha)
                .IsRequired();

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .IsRequired();

            builder.Property(x => x.Mtb)
                .IsRequired(false);

            builder
                .HasMany(x => x.FilmesFavoritos)
                .WithMany(x => x.UsuariosQueFavoritaram)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesFavoritos",
                    filme => filme.HasOne<Filme>()
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .HasConstraintName("FK_FilmesFavoritos_FilmeId")
                        .OnDelete(DeleteBehavior.Cascade),
                    usuario => usuario.HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_FilmesFavoritos_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder
                .HasMany(x => x.FilmesCurtidos)
                .WithMany(x => x.UsuariosQueCurtiram)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesCurtidos",
                    filme => filme.HasOne<Filme>()
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .HasConstraintName("FK_FilmesCurtidos_FilmeId")
                        .OnDelete(DeleteBehavior.Cascade),
                    usuario => usuario.HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_FilmesCurtidos_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
