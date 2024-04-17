using CinePlayers.ViewModels.SalaCinemas;

namespace CinePlayers.Models
{
    public class SalaCinema
    {
        protected SalaCinema() { }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public List<Sessao> Sessoes { get; private set; }

        public SalaCinema(string nome, int capacidade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Capacidade = capacidade;
            Sessoes = new List<Sessao>();
        }

        public void Alterar(UpdateSalaCinemaViewModel model)
        {
            Nome = model.Nome;
            Capacidade = model.Capacidade;
        }
    }
}
