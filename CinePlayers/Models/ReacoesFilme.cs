using CinePlayers.Enums;

namespace CinePlayers.Models
{
    public class ReacoesFilme
    {
        protected ReacoesFilme() {}

        public ReacoesFilme(Usuario usuario, Filme filme, EReacoesFilme reacoes)
        {
            Id = Guid.NewGuid();
            Usuario = usuario;
            Filme = filme;
            Reacoes = reacoes;
        }

        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Filme Filme { get; set; }
        public EReacoesFilme Reacoes { get; set; }
    }
}
