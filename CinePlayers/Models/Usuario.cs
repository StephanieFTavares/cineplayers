using CinePlayers.ViewModels.Usuarios;

namespace CinePlayers.Models
{
    public class Usuario
    {
        public Usuario(string email, string senha, string nome, string cpf, DateTime dataNascimento, string? mtb)
        {
            Id = Guid.NewGuid();
            Email = email;
            Senha = senha;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Mtb = mtb;
            FilmesFavoritos = new List<Filme>();
            FilmesCurtidos = new List<Filme>();
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string? Mtb { get; set; }
        public List<Filme> FilmesFavoritos { get; private set; }
        public List<Filme> FilmesCurtidos { get; private set; }

        public void Alterar(UpdateUsuarioViewModel model)
        {
            Email = model.Email;
            Senha = model.Senha;
            Nome = model.Nome;
            Cpf = model.Cpf;
            DataNascimento = model.DataNascimento;
            Mtb = model.Mtb;
        }
    }
}
