using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.Filmes;
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
                var usuarios = await _context.Usuarios.ToListAsync();
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
    }
}
