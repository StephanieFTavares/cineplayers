namespace CinePlayers.Models
{
    public class AvaliacoesFilme
    {
        protected AvaliacoesFilme(){ }

        public AvaliacoesFilme(Usuario usuario, Filme filme, double avaliacao)
        {
            Id = Guid.NewGuid();
            Usuario = usuario;
            Filme = filme;
            Avaliacao = avaliacao;
        }

        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Filme Filme { get; set; }
        public double Avaliacao { get; set; }
    }
}
