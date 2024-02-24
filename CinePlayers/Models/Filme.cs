namespace CinePlayers.Models
{
    public class Filme
    {
        public Filme( string nome, string elenco, string diretor, string duracao, DateTime anoDeLancamento, string sinopse, double avaliacaoDosCriticos, double avaliacaoDosUsuarios)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Elenco = elenco;
            Diretor = diretor;
            Duracao = duracao;
            AnoDeLancamento = anoDeLancamento;
            Sinopse = sinopse;
            AvaliacaoDosCriticos = avaliacaoDosCriticos;
            AvaliacaoDosUsuarios = avaliacaoDosUsuarios;
        }

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
