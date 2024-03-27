using CinePlayers.Data;
using CinePlayers.Enums;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.Filmes;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateFilmeViewModel model)
        {
            try
            {
                var filme = new Filme(model.Nome, model.Elenco, model.Diretor, model.Duracao, model.AnoDeLancamento,
                    model.Sinopse, model.AvaliacaoDosCriticos, model.AvaliacaoDosUsuarios, model.Tag);

                await _context.Filmes.AddAsync(filme);
                await _context.SaveChangesAsync();

                return Created($"Filme/{filme.Id}", new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateFilmeViewModel model)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                filme.Alterar(model);

                _context.Filmes.Update(filme);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpPost("{idFilme}/Reagir/{idUsuario}")]
        public async Task<IActionResult> ReactionToMovieAsync(Guid idFilme, Guid idUsuario, EReacoesFilme tipoReacao)
        {
            try
            {
                var usuario = await _context
                    .Usuarios
                    .Include(x => x.FilmesFavoritos)
                    .Include(x => x.FilmesReagidos)
                    .FirstOrDefaultAsync(x => x.Id == idUsuario);

                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == idFilme);

                if (usuario is null || filme is null)
                    return NotFound(new ResultViewModel<Usuario>("Conteudo não encontrado"));

                var reacaoExistente = usuario.FilmesReagidos.FirstOrDefault(x => x.Filme.Id == filme.Id);

                if (reacaoExistente is not null)
                    _context.ReacoesFilmes.Remove(reacaoExistente);

                var reacao = new ReacoesFilmes(usuario, filme, tipoReacao);

                await _context.ReacoesFilmes.AddAsync(reacao);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<string>($"{filme.Nome} reagido com sucesso", null));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }
    }
}
