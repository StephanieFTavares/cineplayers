using System.Net;
using CinePlayers.Enums;
using CinePlayers.ViewModels.Filmes;

namespace CinePlayers.Models
{
    public class Filme
    {
        public Filme(string nome, string elenco, string diretor, string duracao, DateTime anoDeLancamento, string sinopse, double avaliacaoDosCriticos, double avaliacaoDosUsuarios, ETagFilme tag)
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
            Tag = tag;
            UsuariosQueFavoritaram = new List<Usuario>();
            UsuariosQueReagiram = new List<ReacoesFilme>();
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
        public ETagFilme Tag { get; private set; }
        public List<Usuario> UsuariosQueFavoritaram { get; private set; }
        public List<ReacoesFilme> UsuariosQueReagiram { get; private set; }

        public void Alterar(UpdateFilmeViewModel model)
        {
            Nome = model.Nome;
            Elenco = model.Elenco;
            Diretor = model.Diretor;
            Duracao = model.Duracao;
            AnoDeLancamento = model.AnoDeLancamento;
            Sinopse = model.Sinopse;
            AvaliacaoDosCriticos = model.AvaliacaoDosCriticos;
            AvaliacaoDosUsuarios = model.AvaliacaoDosUsuarios;
            Tag = model.Tag;
        }

        public void AtualizarAvaliacaoDosUsuarios(int likes, int dislikes)
        {
            if (likes + dislikes > 0)
            {
                int total = likes + dislikes;
                double satisfactionPercentage = ((double)likes / total) * 100;
                AvaliacaoDosUsuarios = Math.Round(satisfactionPercentage, 2);
            }
        }
    }
}
