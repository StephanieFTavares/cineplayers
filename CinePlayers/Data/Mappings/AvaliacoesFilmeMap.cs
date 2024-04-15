using CinePlayers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Data.Mappings
{
    public class AvaliacoesFilmeMap : IEntityTypeConfiguration<AvaliacoesFilme>
    {
        public void Configure(EntityTypeBuilder<AvaliacoesFilme> builder)
        {
            builder.ToTable("FilmesAvaliacoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Avaliacao)
                .IsRequired();

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.FilmesAvaliados);

            builder
                .HasOne(x => x.Filme)
                .WithMany(x => x.UsuariosQueAvaliaram);
        }
    }
}
