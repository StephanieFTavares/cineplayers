using CinePlayers.Enums;

namespace CinePlayers.ViewModels.Filmes
{
    public class CreateFilmeViewModel
    {
        public string Nome { get; set; }
        public string Elenco { get; set; }
        public string Diretor { get; set; }
        public string Duracao { get; set; }
        public DateTime AnoDeLancamento { get; set; }
        public string Sinopse { get; set; }
        public double AvaliacaoDosCriticos { get; set; }
        public double AvaliacaoDosUsuarios { get; set; }
        public ETagFilme Tag { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
    }
}
