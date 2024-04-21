namespace CinePlayers.ViewModels.Reservas
{
    public class GetReservaViewModel
    {
        public Guid ReservaId { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeFilme { get; set; }
        public DateTime DataHoraSessao { get; set; }
        public string SalaNome { get; set; }
        public int NumeroAssento { get; set; }
    }
}
