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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMap());
        }
    }
}
