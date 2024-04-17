using CinePlayers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Data.Mappings
{
    public class SalaCinemaMap : IEntityTypeConfiguration<SalaCinema>
    {
        public void Configure(EntityTypeBuilder<SalaCinema> builder)
        {
            builder.ToTable("SalaCinema");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Capacidade)
                .IsRequired();

            builder
                .HasMany(x => x.Sessoes)
                .WithOne(x => x.Sala);
        }
    }
}
