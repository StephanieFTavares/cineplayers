namespace CinePlayers.ViewModels.SessaoFilme
{
    public class CreateSessaoFilmeViewModel
    {
        public Guid FilmeId { get; set; }         
        public Guid SalaId { get; set; }
        public DateTime DataHoraExibicao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
