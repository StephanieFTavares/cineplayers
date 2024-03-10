namespace CinePlayers.ViewModels.Usuarios
{
    public class UpdateUsuarioViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Mtb { get; set; }
    }
}
