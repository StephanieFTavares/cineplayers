namespace CinePlayers.Models
{
    public class Sessao
    {
        protected Sessao() { }

        public Guid Id { get; private set; }
        public Filme Filme { get; private set; }
        public DateTime DataHora { get; private set; }
        public SalaCinema Sala { get; private set; }
        public List<Reserva> Reservas { get; private set; }

        public Sessao(Filme filme, DateTime dataHora, SalaCinema sala)
        {
            Id = Guid.NewGuid();
            Filme = filme;
            DataHora = dataHora;
            Sala = sala;
            Reservas = new List<Reserva>();
        }
    }
}
