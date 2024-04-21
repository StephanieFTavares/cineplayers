namespace CinePlayers.Models
{
    public class Sessao
    {
        protected Sessao() { }

        public Guid Id { get; private set; }
        public Filme Filme { get; private set; }
        public DateTime DataHoraExibicao { get; private set; }
        public SalaCinema Sala { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }
        public List<Reserva> Reservas { get; private set; }

        public Sessao(Filme filme, DateTime dataHoraExibicao, DateTime dataEntrada, DateTime dataSaida, SalaCinema sala)
        {
            Id = Guid.NewGuid();
            Filme = filme;
            DataHoraExibicao = dataHoraExibicao;
            Sala = sala;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            Reservas = new List<Reserva>();
        }
    }
}
