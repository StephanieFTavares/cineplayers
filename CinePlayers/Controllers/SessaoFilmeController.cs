using CinePlayers.Data;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.Reservas;
using CinePlayers.ViewModels.SessaoFilme;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoFilmeController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;

        public SessaoFilmeController(CinePlayersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var sessoesFilmes = await _context.Sessoes
                    .Include(s => s.Filme)
                    .Include(s => s.Sala)
                    .Include(s => s.Reservas)
                    .ThenInclude(r => r.Usuario)
                    .Select(s => new SessaoViewModel
                    {
                        Id = s.Id,
                        DataHoraExibicao = s.DataHoraExibicao,
                        DataEntrada = s.DataEntrada,
                        DataSaida = s.DataSaida,
                        NomeFilme = s.Filme.Nome,
                        NomeSala = s.Sala.Nome,
                        Reservas = s.Reservas.Select(r => new ReservaViewModel
                        {
                            Id = r.Id,
                            NomeUsuario = r.Usuario.Nome,
                            NumeroAssento = r.NumeroAssento
                        }).ToList()
                    })
                    .ToListAsync();

                return Ok(new ResultViewModel<List<SessaoViewModel>>(sessoesFilmes));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Sessao>>("Falha interna no servidor."));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var sessao = await _context.Sessoes
                    .Include(s => s.Filme)
                    .Include(s => s.Sala)
                    .Include(s => s.Reservas)
                    .ThenInclude(r => r.Usuario)
                    .Select(s => new SessaoViewModel
                    {
                        Id = s.Id,
                        DataHoraExibicao = s.DataHoraExibicao,
                        DataEntrada = s.DataEntrada,
                        DataSaida = s.DataSaida,
                        NomeFilme = s.Filme.Nome,
                        NomeSala = s.Sala.Nome,
                        Reservas = s.Reservas.Select(r => new ReservaViewModel
                        {
                            Id = r.Id,
                            NomeUsuario = r.Usuario.Nome,
                            NumeroAssento = r.NumeroAssento
                        }).ToList()
                    })
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (sessao == null)
                    return NotFound(new ResultViewModel<Sessao>("A Sessão deste Filme não foi encontrada."));

                return Ok(new ResultViewModel<SessaoViewModel>(sessao));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Sessao>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSessao([FromBody] CreateSessaoFilmeViewModel model)
        {
            try
            {
                var sala = await _context.SalaCinemas.FirstOrDefaultAsync(x => x.Id == model.SalaId);
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == model.FilmeId);

                if (sala is null || filme is null)
                    return NotFound(new ResultViewModel<Sessao>("Sala ou filme não encontrado."));

                var sessao = new Sessao(filme, model.DataHoraExibicao, model.DataEntrada, model.DataSaida, sala);

                _context.Sessoes.Add(sessao);
                await _context.SaveChangesAsync();

                var sessaoViewModel = new SessaoViewModel
                {
                    Id = sessao.Id,
                    DataHoraExibicao = sessao.DataHoraExibicao,
                    DataEntrada = sessao.DataEntrada,
                    DataSaida = sessao.DataSaida,
                    NomeFilme = filme.Nome,
                    NomeSala = sala.Nome
                };

                return Created($"SessaoFilme/{sessao.Id}", new ResultViewModel<SessaoViewModel>(sessaoViewModel));
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpPost("Reservar")]
        public async Task<IActionResult> ReservarAssento(Guid sessaoId, [FromBody] ReservaAssentoViewModel model)
        {
            var sessao = await _context.Sessoes
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .Include(s => s.Reservas)
                .FirstOrDefaultAsync(s => s.Id == sessaoId);
            if (sessao is null)
                return NotFound(new ResultViewModel<Sessao>("Sala não encontrado."));

            if (sessao.Reservas.Any(r => r.NumeroAssento == model.NumeroAssento))
                return BadRequest(new ResultViewModel<Sessao>("Assento já está reservado."));

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == model.UsuarioId);
            if (usuario is null)
                return NotFound(new ResultViewModel<Sessao>("Usuário não encontrado."));

            var reserva = new Reserva(usuario, sessao, model.NumeroAssento);
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            var reservaViewModel = new GetReservaViewModel
            {
                ReservaId = reserva.Id,
                NomeUsuario = usuario.Nome,
                NomeFilme = sessao.Filme.Nome,
                DataHoraSessao = sessao.DataHoraExibicao,
                SalaNome = sessao.Sala.Nome,
                NumeroAssento = reserva.NumeroAssento
            };

            return Created($"SessaoFilme/{sessao.Id}/reservas/{reserva.Id}", new ResultViewModel<GetReservaViewModel>(reservaViewModel));
        }
    }
}
