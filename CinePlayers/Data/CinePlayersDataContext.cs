using CinePlayers.Data.Mappings;
using CinePlayers.Models;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Data
{
    public class CinePlayersDataContext : DbContext
    {
        public CinePlayersDataContext(DbContextOptions<CinePlayersDataContext> options) : base(options)
        {       
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ReacoesFilme> ReacoesFilmes { get; set; }
        public DbSet<AvaliacoesFilme> AvaliacoesFilmes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<SalaCinema> SalaCinemas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public object SessaoFilme { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ReacoesFilmesMap());
            modelBuilder.ApplyConfiguration(new AvaliacoesFilmeMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new SalaCinemaMap());
            modelBuilder.ApplyConfiguration(new SessaoMap());
        }
    }
}
