namespace CinePlayers.Models
{
    public class Filme
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Elenco { get; private set; }
        public string Diretor { get; private set; }
        public string Duracao { get; private set; }
        public DateTime AnoDeLancamento { get; private set; }
        public string Sinopse { get; private set; }
        public double AvaliacaoDosCriticos { get; private set; }
        public double AvaliacaoDosUsuarios { get; private set; }
    }
}
