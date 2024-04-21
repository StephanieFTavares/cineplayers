namespace CinePlayers.ViewModels.SessaoFilme
{
    public class SessaoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataHoraExibicao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string NomeFilme { get; set; }
        public string NomeSala { get; set; }
        public List<ReservaViewModel> Reservas { get; set; }
    }

    public class ReservaViewModel
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public int NumeroAssento { get; set; }
    }
}
