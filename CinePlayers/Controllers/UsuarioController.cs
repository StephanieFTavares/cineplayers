using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;

        public UsuarioController(CinePlayersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var usuarios = await _context.Usuarios.Include(u => u.FilmesFavoritos)
                    .Include(u => u.FilmesCurtidos).ToListAsync();
                return Ok(new ResultViewModel<List<Usuario>>(usuarios));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Usuario>>("Falha interna no servidor"));
            }
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nome == nome);

                if (usuario is null)
                    return NotFound(new ResultViewModel<Usuario>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateUsuarioViewModel model)
        {
            try
            {
                var usuario = new Usuario(model.Email, model.Senha, model.Nome, model.Cpf, model.DataNascimento, model.Mtb);

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Created($"Usuario/{usuario.Id}", new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateUsuarioViewModel model)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario is null)
                    return NotFound(new ResultViewModel<Usuario>("Conteudo não encontrado"));

                usuario.Alterar(model);

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario is null)
                    return NotFound(new ResultViewModel<Usuario>("Conteudo não encontrado"));

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }

        [HttpPost("{idUsuario}/GerenciarFilmesFavoritos/{idFilme}")]
        public async Task<IActionResult> ManageFavoriteMovieAsync(Guid idUsuario, Guid idFilme)
        {
            try
            {
                var usuario = await _context.Usuarios.Include(x => x.FilmesFavoritos).FirstOrDefaultAsync(x => x.Id == idUsuario);
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == idFilme);

                if (usuario is null || filme is null)
                    return NotFound(new ResultViewModel<Usuario>("Conteudo não encontrado"));

                if (usuario.FilmesFavoritos.Any(x => x.Id == filme.Id))
                {
                    usuario.FilmesFavoritos.Remove(filme);
                    await _context.SaveChangesAsync();
                    return Ok(new ResultViewModel<string>($"{filme.Nome} removido dos favoritos", null));
                }

                usuario.FilmesFavoritos.Add(filme);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<string>($"{filme.Nome} adicionado aos favoritos com sucesso", null));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }

        [HttpGet("{idUsuario}/BuscarFilmesFavoritos")]
        public async Task<IActionResult> GetFavoriteMoviesAsync(Guid idUsuario)
        {
            try
            {
                var filmesFavoritos = await _context.Usuarios
                    .AsNoTracking()
                    .Where(usuario => usuario.Id == idUsuario)
                    .SelectMany(usuario => usuario.FilmesFavoritos)
                    .Select(filme => new GetFavoriteFilmesViewModel
                    {
                        Nome = filme.Nome
                    })
                    .ToListAsync();

                if (!filmesFavoritos.Any())
                    return NotFound(new ResultViewModel<Usuario>("Usuário não encontrado ou não possui filmes favoritos"));

                return Ok(new ResultViewModel<List<GetFavoriteFilmesViewModel>>(filmesFavoritos));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }
    }
}
