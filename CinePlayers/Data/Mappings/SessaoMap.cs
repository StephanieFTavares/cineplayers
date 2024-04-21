using CinePlayers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Data.Mappings
{
    public class SessaoMap : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessao");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Filme)
                .WithMany(x => x.Sessoes);

            builder.Property(x => x.DataHoraExibicao)
                .IsRequired();

            builder
                .HasMany(x => x.Reservas)
                .WithOne(x => x.Sessao);

            builder.Property(x => x.DataEntrada)
                .IsRequired();

            builder.Property(x => x.DataSaida)
                .IsRequired();
        }
    }
}
