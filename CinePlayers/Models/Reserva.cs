namespace CinePlayers.Models
{
    public class Reserva
    {
        protected Reserva() { }

        public Guid Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public Sessao Sessao { get; private set; }
        public int NumeroAssento { get; private set; }

        public Reserva(Usuario usuario, Sessao sessao, int numeroAssento)
        {
            Id = Guid.NewGuid();
            Usuario = usuario;
            Sessao = sessao;
            NumeroAssento = numeroAssento;
        }
    }
}
