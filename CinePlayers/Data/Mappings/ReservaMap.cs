using CinePlayers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Data.Mappings
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Reservas);

            builder.Property(x => x.NumeroAssento)
                .IsRequired();
        }
    }
}
