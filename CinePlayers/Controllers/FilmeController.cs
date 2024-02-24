using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;

        public FilmeController(CinePlayersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var filmes = await _context.Filmes.ToListAsync();
                return Ok(new ResultViewModel<List<Filme>>(filmes));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Nome == nome);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }
    }
}
