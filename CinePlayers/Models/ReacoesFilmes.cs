using CinePlayers.Enums;

namespace CinePlayers.Models
{
    public class ReacoesFilmes
    {
        protected ReacoesFilmes() {}

        public ReacoesFilmes(Usuario usuario, Filme filme, EReacoesFilme reacoes)
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
