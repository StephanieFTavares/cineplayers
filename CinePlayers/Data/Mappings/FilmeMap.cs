using CinePlayers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlayers.Data.Mappings
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.Property(x => x.Elenco)
                .IsRequired();

            builder.Property(x => x.Diretor)
                .IsRequired();

            builder.Property(x => x.Duracao)
                .IsRequired(); 

            builder.Property(x => x.AnoDeLancamento)
                .IsRequired(); 

            builder.Property(x => x.Sinopse)
                .IsRequired(); 

            builder.Property(x => x.AvaliacaoDosCriticos)
                .IsRequired();

            builder.Property(x => x.AvaliacaoDosUsuarios)
                .IsRequired();

            builder.Property(x => x.Tag)
                .IsRequired();

            builder.Property(x => x.Categoria)
                .IsRequired();

            builder.Property(x => x.Imagem)
                .IsRequired(false);
        }
    }
}
