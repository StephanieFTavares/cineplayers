using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.SalaCinemas;
using CinePlayers.ViewModels.SessaoFilme;
using CinePlayers.ViewModels.SessaoFilmeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoFilmeController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;
        private object nome;
        private object capacidade;

        public SessaoFilmeController(CinePlayersDataContext context)
        {
            _context = context;
        }

        public SessaoFilmeController(object nome, object capacidade)
        {
            this.nome = nome;
            this.capacidade = capacidade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var sessaoFilme = await _context.SessaoFilme.ToListAsync();
                return Ok(new ResultViewModel<List<SessaoFilmeController>>(sessaoFilme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<SalaCinema>>("Falha interna no servidor."));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var sessaoFilme = await _context.SessaoFilme.FirstOrDefaultAsync(x => x.Id == id);
                if (sessaoFilme is null)
                    return NotFound(new ResultViewModel<SalaCinema>("A Sessão deste Filme não foi encontrada."));

                return Ok(new ResultViewModel<SalaCinema>(sessaoFilme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SessaoFilmeController>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateSessaoFilmeViewModel model)
        {
            try
            {
                var sessaoFilme = new SessaoFilmeController(model.DataHora, model.Filme);
                _context.SessaoFilme.Add(sessaoFilme);
                await _context.SaveChangesAsync();
                return Created($"SessaoFilme/{sessaoFilme.Id}", new ResultViewModel<SalaCinema>(sessaoFilme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateSessaoFilmeViewModel model)
        {
            try
            {
                var sessaoFilme = await _context.SessaoFilme.FirstOrDefaultAsync(x => x.Id == id);
                if (sessaoFilme is null)
                    return NotFound(new ResultViewModel<SalaCinema>("A Sessão deste Filme não foi encontrada"));

                sessaoFilme.Alterar(model);
                _context.SessaoFilme.Update(sessaoFilme);
                await _context.SaveChangesAsync();
                return Ok(new ResultViewModel<SessaoFilme>(sessaoFilme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }

    }
}
