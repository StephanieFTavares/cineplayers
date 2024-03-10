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
        }
    }
}
