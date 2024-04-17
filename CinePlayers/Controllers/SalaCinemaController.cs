using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.SalaCinemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaCinemaController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;

        public SalaCinemaController(CinePlayersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var salaCinema = await _context.SalaCinemas.ToListAsync();
                return Ok(new ResultViewModel<List<SalaCinema>>(salaCinema));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<SalaCinema>>("Falha interna no servidor"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var salaCinema = await _context.SalaCinemas.FirstOrDefaultAsync(x => x.Id == id);
                if (salaCinema is null)
                    return NotFound(new ResultViewModel<SalaCinema>("Sala de cinema não encontrada"));

                return Ok(new ResultViewModel<SalaCinema>(salaCinema));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateSalaCinemaViewModel model)
        {
            try
            {
                var salaCinema = new SalaCinema(model.Nome, model.Capacidade);
                _context.SalaCinemas.Add(salaCinema);
                await _context.SaveChangesAsync();
                return Created($"SalaCinema/{salaCinema.Id}", new ResultViewModel<SalaCinema>(salaCinema));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateSalaCinemaViewModel model)
        {
            try
            {
                var salaCinema = await _context.SalaCinemas.FirstOrDefaultAsync(x => x.Id == id);
                if (salaCinema is null)
                    return NotFound(new ResultViewModel<SalaCinema>("Sala de cinema não encontrada"));

                salaCinema.Alterar(model);
                _context.SalaCinemas.Update(salaCinema);
                await _context.SaveChangesAsync();
                return Ok(new ResultViewModel<SalaCinema>(salaCinema));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var salaCinema = await _context.SalaCinemas.FirstOrDefaultAsync(x => x.Id == id);
                if (salaCinema is null)
                    return NotFound(new ResultViewModel<SalaCinema>("Sala de cinema não encontrada"));

                _context.SalaCinemas.Remove(salaCinema);
                await _context.SaveChangesAsync();
                return Ok(new ResultViewModel<SalaCinema>(salaCinema));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<SalaCinema>("Falha interna no servidor"));
            }
        }
    }
}
