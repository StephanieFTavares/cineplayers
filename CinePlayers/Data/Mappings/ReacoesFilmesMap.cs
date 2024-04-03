using CinePlayers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlayers.Data.Mappings
{
    public class ReacoesFilmesMap : IEntityTypeConfiguration<ReacoesFilme>
    {
        public void Configure(EntityTypeBuilder<ReacoesFilme> builder)
        {
            builder.ToTable("FilmesReacoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Reacoes)
                .IsRequired();

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.FilmesReagidos);

            builder
                .HasOne(x => x.Filme)
                .WithMany(x => x.UsuariosQueReagiram);
        }
    }
}
